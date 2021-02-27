using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        //bir iş sınıfı, başka bir sınıfı new'lemez!

        ICarDal _carDal;

        public CarManager(ICarDal carDal) //constructer'a ICarDal referansı verilir. İleride değiştirilebilir.
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            // iş koşul kodları
            return _carDal.GetAll();


        }

       
        public void Add(Car car)
        {
            if (car.DailyPrice > 0 && car.Description.Length > 2)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Günlük kiralama ücreti 0'dan büyük ve araba açıklaması" +
                    " 2 harften büyük olmalı! ");
            }
        }

        public void Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int carId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}