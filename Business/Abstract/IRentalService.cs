﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> Get(int id);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IResult Insert(Rental rental);
        IResult ReturnRent(Rental rental);

    }
}
