using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace TheUI
{
    class Program
    {
        static void Main(string[] args)
        {

            ProductManager productManager = new ProductManager(new InMemoryProductDal());

            foreach (var car in productManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
