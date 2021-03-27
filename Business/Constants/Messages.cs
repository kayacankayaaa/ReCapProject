using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarDescriptionInvalid = "Araba ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarsListed = "Arabalar listelendi";
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandsListed = "Markalar listelendi";
        public static string RentalAdded = "Yeni Kiralama Eklenmiştir";
        public static string RentalListed = "Kiralık arabalar listelendi";
        public static string RentalInvalid = "Araba teslim edilmediği için kiralanamaz!";
        public static string CarImageLimitExceded ="En fazla 5 adet fotoğraf eklenebilir!";
        public static string FileAdded = "Fotoğraf eklendi";
        public static string AuthorizationDenied = "Erişme yetkiniz yoktur!";
        public static string UserRegistered = "Kayıt olundu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError ="Parola hatası";
        public static string SuccessfulLogin="Başarılı giriş";
        public static string UserAlreadyExists="Kullanıcı mevcut";
        public static string AccessTokenCreated ="Token oluşturuldu";
    }
}
