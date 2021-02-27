﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(int carId);
        void Delete(Car car);
        void Add(Car car);
        void Update(Car car);

        List<CarDetailDto> GetCarDetails();



    }
}
