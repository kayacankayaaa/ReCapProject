using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } //api'deki "appsettings"i okumaya yarar
        private TokenOptions _tokenOptions; //okunan değerler nesneye atılır
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration) //API'yı enjekte eder
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); //"appsettings"i alır ve tokenoptions ile eşleştirir

        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            //user ve claimlere göre token oluşturur
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration); //10 dk süre
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey); //güvenlik anahtarı oluşturulur
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey); //algoritma çağırılır
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims); //tokenoptionları kullanılarak ilgili kullanıcılara yetkiler atanır
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            //jwt token oluşturur
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        //claimler oluşturulur
        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.UserId.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}"); //iki stringi yan yana göstermeye yarar
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
