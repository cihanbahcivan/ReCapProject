using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car(){Id= 1,BrandId = 5,ColorId = 1,DailyPrice = 200,Description = "Passat",ModelYear = 2012},
                new Car(){Id= 2,BrandId = 1,ColorId = 1,DailyPrice = 1000,Description = "Supra",ModelYear = 2000},
                new Car(){Id= 3,BrandId = 1,ColorId = 2,DailyPrice = 150,Description = "Corolla",ModelYear = 2006},
                new Car(){Id= 4,BrandId = 1,ColorId = 3,DailyPrice = 450,Description = "Celica",ModelYear = 2002},
                new Car(){Id= 5,BrandId = 2,ColorId = 4,DailyPrice = 2000,Description = "Camaro",ModelYear = 2013},
                new Car(){Id= 6,BrandId = 2,ColorId = 5,DailyPrice = 275,Description = "Cruz",ModelYear = 2010},
                new Car(){Id= 7,BrandId = 3,ColorId = 6,DailyPrice = 300,Description = "Fiesta",ModelYear = 2015},
                new Car(){Id= 8,BrandId = 3,ColorId = 7,DailyPrice = 250,Description = "Focus",ModelYear = 2008},
                new Car(){Id= 9,BrandId = 4,ColorId = 8,DailyPrice = 1750,Description = "Skyline",ModelYear = 2000},
                new Car(){Id= 10,BrandId = 4,ColorId = 9,DailyPrice = 750,Description = "350Z",ModelYear = 2001}
            };
        }
        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
