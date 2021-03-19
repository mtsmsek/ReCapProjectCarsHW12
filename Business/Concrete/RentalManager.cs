using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var checkRental = (_rentalDal.GetAll(r => r.CarId == rental.CarId).OrderByDescending(r=>r.RentDate)).FirstOrDefault();          
            if (checkRental == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.CarRented);
            }
            else if ((checkRental.ReturnDate !=null) && (rental.RentDate > checkRental.ReturnDate))
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.CarRented);

            }
            else
            {
                return new ErrorResult();

            }





        }



        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
            return new ErrorDataResult<List<Rental>>(_rentalDal.GetAll());

        }

        public IDataResult<Rental> GetByRentalId(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p=> p.Id == id));
            return new ErrorDataResult<Rental>(_rentalDal.Get(p => p.Id != id));

        }
        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(p => p.CarId == carId));
            return new ErrorDataResult<List<Rental>>(_rentalDal.GetAll(p => p.CarId  != carId));

        }

        public IResult Update(Rental rental)
        {
            
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public IDataResult<List<CarRentalDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<CarRentalDto>>(_rentalDal.GetRentalDetails());
        }
    }
}
