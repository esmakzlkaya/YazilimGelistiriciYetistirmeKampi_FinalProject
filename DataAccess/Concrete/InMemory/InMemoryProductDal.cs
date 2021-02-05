using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle, Sql, Postgres, MongoDb
            _products = new List<Product> {
            new Product{CategoryId=1,ProductId=1,ProductName="Bardak",UnitsInStock=15,UnitPrice=15},
            new Product{CategoryId=2,ProductId=2,ProductName="Kamera",UnitsInStock=500,UnitPrice=3},
            new Product{CategoryId=3,ProductId=3,ProductName="Telefon",UnitsInStock=1500,UnitPrice=2},
            new Product{CategoryId=5,ProductId=4,ProductName="Klavye",UnitsInStock=150,UnitPrice=65},
            new Product{CategoryId=6,ProductId=5,ProductName="Fare",UnitsInStock=85,UnitPrice=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query
            // =>  lamda işareti
            //   Product productToDelete=null;
            /* foreach (var p in _products)
             {
                 if (product.ProductId==p.ProductId)
                 {
                     productToDelete = p;
                 }
             }  */
            //linq - yukarıdaki kodların yaptığı işi tek başına yapar
            // her p için tek tek dolaşır,
            // id bazlı yapılarda SİngkeOrDefault kullanırız
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id sine sahip ürünü listeden bul, artık aynı referansa sahip olurlar
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=>p.CategoryId==categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
