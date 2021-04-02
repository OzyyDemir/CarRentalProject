using Core.Utilities.Result;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file,CarImage carImages);
        IResult Delete(CarImage carImages);
        IResult Update(CarImage carImages, IFormFile file);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> Get(int id);
    }
}
