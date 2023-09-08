using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
    private readonly IProductService productService;

    public ProductController(IProductService _productService)
    {
      this.productService = _productService;
    }

    [HttpGet]
    [Route("/product/getAll")]
    public IQueryable<Product> GetAll()
    {
        return productService.GetProductList();
    }

    [HttpPost]
    [Route("/product/add")]
    public bool AddProduct(Product newProduct)
    {         
       return productService.AddProduct(newProduct);            
    }   

    [HttpDelete]
    [Route("/product/delete")]
    public bool DeleteProduct (int id)
    {
      return productService.DeleteProduct(id); 
    }
    }
}
