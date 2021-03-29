using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {

            ValidationTool.Validate(new CarValidator(), car);

            _carDal.Add(car);
             return new SuccessResult(Messages.CarAdded);            
        }

        public IResult Delete(Car car)
        {
            throw new NotImplementedException();
        }
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            throw new NotImplementedException();
        }

        [CacheAspect]
        [PerformanceAspect(5)] // 5sn'yi geçerse uyar
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice<100)
            {
                throw new Exception("");
            }
            Add(car);
            return null;
        }
    }
}