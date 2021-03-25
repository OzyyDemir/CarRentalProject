using Core.Utilities.Result;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {

        IDataResult<List<Customer>> GetAll();

        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();

        IResult Add(Customer customer);

        IResult Update(Customer customer);

        IResult Delete(Customer customer);
    }
}
