using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            IResult result = BusinessRules.Run(
                CheckIfCategoryNameDuplicate(category.CategoryName)
                );

            if (result != null) //hatalı kodlar kendi hata mesajıyla dönüyor, hatalı olmayanlara null döndük
            {
                return result; // hatalı logic, hata mesajı döner
            }
            _categoryDal.Add(category);

            return new SuccessResult();
        }

        //[TransactionScopeAspect]
        public IResult AddTransactionalTest(Category category)
        {
            throw new Exception();
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult();
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
        }

        //[CacheRemoveAspect("IProductService.Get")]
        //[ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Category category)
        {
            IResult result = BusinessRules.Run(
                 CheckIfCategoryNameDuplicate(category.CategoryName)
                 );

            if (result != null) //hatalı kodlar kendi hata mesajıyla dönüyor, hatalı olmayanlara null döndük
            {
                return result; // hatalı logic, hata mesajı döner
            }
            _categoryDal.Update(category);
            return new SuccessResult();
        
        }
        private IResult CheckIfCategoryNameDuplicate(string categoryName)
        {
            var result = _categoryDal.GetAll(p => p.CategoryName == categoryName);
            if (result.Count > 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
