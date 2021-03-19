using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult <Rental> GetByRentalId(int id);
        IDataResult<List<Rental>> GetByCarId(int carId);
        IDataResult<List<CarRentalDto>> GetRentalDetails();


    }
}
