using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new Result(true, Messages.ProductUpdated);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new Result(true, Messages.ProductDeleted);
        }

        public IResult Insert(Rental rental)
        {
            if (rental.ReturnDate != null)
            {
                _rentalDal.Insert(rental);
                return new Result(true, Messages.ProductAdded);
            }
            else
            {
                return new ErrorResult("Henüz teslim edilmedi");
            }
        }

        public IResult ReturnRent(Rental rental)
        {
            var car =_rentalDal.Get(c => c.Id == rental.Id && c.ReturnDate == null);
            car.ReturnDate = DateTime.Now;
            _rentalDal.Update(car);
            return new Result(true,"Araç teslim edildi");
        }
    }
}
