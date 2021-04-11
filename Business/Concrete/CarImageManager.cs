using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Result;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImage)
        {
            _carImageDal = carImage;
        }
        //[SecuredOperation("carimage.add,admin")]
        //[PerformanceAspect(7)]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage, int carId)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carId));
            if (result != null)
            {
                return result;
            }
            var imageResult = FileHelper.Add(file);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.succeed);
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CarImageDelete(carImage));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }
        //[CacheAspect]
        //[PerformanceAspect(7)]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.listed);
        }

        //! Refactor Et
        //[CacheAspect]
        //[PerformanceAspect(7)]
        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            string path = "/images/sirketlogo.jpg";
            var result = _carImageDal.GetAll(carImage => carImage.CarId == carId).Any();
            if (!result)
            {
                List<CarImage> carimage = new List<CarImage>();
                carimage.Add(new CarImage { CarId = carId, ImagePath = path });
                return new SuccessDataResult<List<CarImage>>(carimage);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId), Messages.succeed);

        }



        public IResult Update(IFormFile image, CarImage carImage)
        {
            var isImage = _carImageDal.Get(c => c.CarId == carImage.CarId);

            var updatedFile = FileHelper.Update(image, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult("Car image updated");

        }

        private IResult CheckImageLimitExceeded(int id)
        {
            if (_carImageDal.GetAll(image => image.CarId == id).Count >= 3)
            {
                return new ErrorResult(Messages.CarImagesCountExceded);
            }

            return new SuccessResult();

        }
        //[CacheAspect]
        //[PerformanceAspect(7)]
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }
        private IResult CarImageDelete(CarImage carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var getAllbyCarIdResult = _carImageDal.GetAll(p => p.CarId == carId);
            if (getAllbyCarIdResult.Count == 0)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage>
                {
                    new CarImage
                    {
                        Id = -1,
                        CarId = carId,
                        Date = DateTime.MinValue,
                        ImagePath = "images/sirketlogo.jpg"
                    }
                });
            }

            return new SuccessDataResult<List<CarImage>>(getAllbyCarIdResult);
        }
    }
}