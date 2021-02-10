using System;
using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //CategoryTest();

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductsDetails();
            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    //join işlemi yapıldı categori adı da geldi
                    Console.WriteLine(product.ProductName + " / " + product.CategoryName);
                }
            }
            else
            Console.WriteLine(result.Message);
        }
    }
}
