using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();// hem işlem sonucu hemde mesaj döndürecek
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductsDetails();
        IDataResult<Product> GetByID(int id);
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
        IResult AddTransactionalTest(Product product);
    }
}
