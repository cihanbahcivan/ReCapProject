using System;
using System.Runtime.InteropServices;
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
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            rentalManager.Insert(new Rental
            {
                Id = 3,
                CarId = 3,
                CustomerId = 3,
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Now,
            });
            var result = rentalManager.GetAll().Data;
            foreach (var res in result)
            {
                Console.WriteLine(res.ReturnDate);
            }
            //CarTest(carManager);
        }

        private static void CarTest(CarManager carManager)
        {
            var result = carManager.GetAll();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
