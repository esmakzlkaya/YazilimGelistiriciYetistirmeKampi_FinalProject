using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;
using FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Business.CrossCuttingConcerns_Demo;
using Core.Utilities.Business;
using DataAccess.Concrete.EntityFramework;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        //ProductManager newlendiğinde IProductDal referansı ver 
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

       // [CacheAspect] //key, value
        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour == 23)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        [CacheAspect]
        public IDataResult<Product> GetByID(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductsDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
        // [LogAspect]--> AOP işlemine örnek
        // sen nerede dersen orada çalışır,

        //Cross cutting concerns - Log, cache, transaction yönetimi, authorization

        //[CacheRemoveAspect("IProductService.Get")]
        //[SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))] // typeof ile attribute a tip atıyoruz
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(
                CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfProductNameDuplicate(product.ProductName),
                CheckIfCategoryLimitExceeded());

            if (result != null) //hatalı kodlar kendi hata mesajıyla dönüyor, hatalı olmayanlara null döndük
            {
                return result; // hatalı logic, hata mesajı döner
            }
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IProductService.Get")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            IResult result = BusinessRules.Run(
                CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfProductNameDuplicate(product.ProductName),
                CheckIfCategoryLimitExceeded());

            if (result != null) //hatalı kodlar kendi hata mesajıyla dönüyor, hatalı olmayanlara null döndük
            {
                return result; // hatalı logic, hata mesajı döner
            }
            _productDal.Update(product);
            return new SuccessResult();
        }
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameDuplicate(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        //product için category nin nasıl yorumlandığını görmek için yaptık,
        //    categoryService i sistemimize enjekte ettik
        private IResult CheckIfCategoryLimitExceeded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceeded);
            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            _productDal.Add(product);
            if (product.UnitPrice<5)
            {
                throw new Exception("Birim fiyatı 5'den küçük olamaz!");
            }
            return new SuccessResult(Messages.TransactionSucceed);
        }
    }
}
