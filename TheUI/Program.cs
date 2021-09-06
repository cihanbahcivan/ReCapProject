using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace TheUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine(carManager.Add(new Car()
                { Id = 1, BrandId = 1, ColorId = 1, Description = "Aciklama", DailyPrice = 100, ModelYear = 2020 }));
        }
    }
}
