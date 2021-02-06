using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //Süper bir olay ***
    public interface IProductDal:IEntityRepository<Product>
    {
        //yalnızca ürünü ilgilendiren işlemleri burada yapıcaz
        //Ürüne ait ayrıntılı listeleme
        //join işlemlerini burada yazıcaz

        List<ProductDetailDto> GetProductDetails();

    }
}

//Code Refactoring - Kod İyileştirmesi