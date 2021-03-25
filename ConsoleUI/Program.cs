using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
             //CarTest();
            //BrandTest();
            //CustomerTest();
        }
        private static void CustomerTest()
        {
            CustomerManager  customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var customer in customerManager.GetCustomerDetails().Data)
            {
                Console.WriteLine(customer.FirstName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName +" " + car.BrandName);
            }
        }
    }
}
