using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//RESTFUL --> HTTP --> TCP
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //Attribute(C#) class ile ilgili bilgi verme, onu imzalama yöntemi
    //, Annotation(Java)
    public class ProductsController : ControllerBase
    {
        //Loosely coupled
        //naming convention
        //IoC Container -- Inversion of Control -- Değişimin kontrolü
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger
            //Dependency Chain
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result); 
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetByID(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycategoryid")]
        public IActionResult GetByCategoryId(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("transaction")]
        public IActionResult AddTransactionalTest(Product product)
        {
            var result = _productService.AddTransactionalTest(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //güncelleme için de post kullanabiliriz 
        //sektörde silme ve güncelleme için de çoğunlukla post kullanılır
        //ayırmak istersek, put = güncelleme, delete = silme için
    }
}
