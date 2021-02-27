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
            CarManager carManager = new CarManager(new EfCarDal());

         
            foreach (var car in carManager.GetAll())
            {
                System.Console.WriteLine(car.Description);
            }

            Car car1 = new Car()
            {
                BrandId = 2,
                CarId = 4,
                ColorId = 1,
                DailyPrice = 265,
                Description = "Yarı-Otomatik",
                ModelYear = 2015

            };
            carManager.AddCar(car1);

             
                       
        }
    }
}
