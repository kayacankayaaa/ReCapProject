﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> 
            { 
                new Car {CarId=1,BrandId=1,ColorId=1,DailyPrice=200,Description="Mercedes",ModelYear=2013},
                new Car {CarId=2,BrandId=1,ColorId=2,DailyPrice=175,Description="Mercedes",ModelYear=2011},
                new Car {CarId=3,BrandId=2,ColorId=3,DailyPrice=250,Description="Audi",ModelYear=2015},
                new Car {CarId=4,BrandId=2,ColorId=2,DailyPrice=300,Description="Audi",ModelYear=2017},
                new Car {CarId=5,BrandId=3,ColorId=1,DailyPrice=150,Description="Ford",ModelYear=2010},
                new Car {CarId=6,BrandId=4,ColorId=3,DailyPrice=220,Description="Honda",ModelYear=2012},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId );
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
          
        }


        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.CarId = car.CarId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}