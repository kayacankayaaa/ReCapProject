using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarAddTest();
            //BrandTest();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Rental rental2 = new Rental()
            {
                CarId = 4,
                CustomerId = 5,
                RentDate = Convert.ToDateTime("01.03.2021"),
                ReturnDate = Convert.ToDateTime("01.12.2021")
            };

            var result = rentalManager.Add(rental2);
            System.Console.WriteLine(result.Message);
          
        }

               

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetAll();

            if (result.Success ==true)
            {
                foreach (var brand in result.Data)
                {
                    System.Console.WriteLine(brand.BrandName);
                }
            }
            
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    System.Console.WriteLine(car.Description + " / " + car.BrandName);
                }
            }

            else
            {
                System.Console.WriteLine(result.Message);
            }


            

            //Car car1 = new Car()
            //{
            //    BrandId = 2,
            //    ColorId = 1,
            //    DailyPrice = 265,
            //    Description = "Yarı-Otomatik",
            //    ModelYear = 2015

            //};
            //carManager.Add(car1);
        }
    }
}