using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IDataResult<List<Car>> GetAll()
        {
            //Her saat 22 de sistemi bakıma alır.
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }


            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }
            
        public IResult Add(Car car)
        {
            if (car.Description.Length<2)
            {
                return new ErrorResult(Messages.CarDescriptionInvalid);
            }
             _carDal.Add(car);
             return new SuccessResult(Messages.CarAdded);            
        }

        public IResult Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Car car)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
    }
}