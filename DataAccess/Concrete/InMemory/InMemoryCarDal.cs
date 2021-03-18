using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
            
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=122,Description="Audi",ModelYear=2020},
                new Car{Id=2,BrandId=2,ColorId=1,DailyPrice=344,Description="Renoult",ModelYear=2020},
                new Car{Id=3,BrandId=3,ColorId=1,DailyPrice=1,Description="Bmw",ModelYear=2020},
                new Car{Id=4,BrandId=3,ColorId=1,DailyPrice=12122,Description="Tofaş",ModelYear=2020},
                new Car{Id=5,BrandId=1,ColorId=1,DailyPrice=122543,Description="Audi",ModelYear=2020},
                new Car{Id=6,BrandId=3,ColorId=1,DailyPrice=143,Description="Bmw",ModelYear=2000}

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
