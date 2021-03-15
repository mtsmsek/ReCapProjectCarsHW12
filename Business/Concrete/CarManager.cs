using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _icarDal;

        public CarManager(ICarDal icarDal)
        {
            _icarDal = icarDal;
        }

        public IResult Add(Car car)
        {
            if (car.ModelYear.Length>2 && car.UnitPrice>0)
            {
                _icarDal.Add(car);
                return new SuccessResult();
            }
            else
            {
               return  new ErrorResult(Messages.InvalidCarName);
            }
            
        }


        public IResult Delete(Car car)
        {
            if (false)
            {
                return new ErrorResult();
            }
            _icarDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_icarDal.GetAll());
        }


        public IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max)
        {

            return new SuccessDataResult<List<Car>>(_icarDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            if (_icarDal.GetCarDetails()==null)
            {
                return new ErrorDataResult<List<CarDetailsDto>>(Messages.CarsNotFound);
            }
            return new SuccessDataResult<List<CarDetailsDto>>(_icarDal.GetCarDetails(),Messages.CarsListed);
        }

        public IResult Update(Car car)
        {
            
            if (car.ModelYear.Length<=2)
            {
                return new ErrorResult();
            }
            _icarDal.Update(car);
            return new SuccessResult("Ürün güncellendi");
        }
    }
}
