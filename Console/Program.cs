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
            CarAddTest();
            //BrandTest();

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                System.Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());


            foreach (var car in carManager.GetCarDetails())
            {
                System.Console.WriteLine(car.Description + " / " + car.BrandName);
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