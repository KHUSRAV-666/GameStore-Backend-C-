using Microsoft.AspNetCore.Mvc;
using GameStore.Api.Models;
using System.Collections.Generic;
using GameStore.Api.Services;
namespace GameStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        // Constructor injection
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // Temporary in-memory list of products
        private static readonly List<Product> Products =
            new() { new Product { Id = Guid.NewGuid(), Name = "Laptop" },
                new Product { Id = Guid.NewGuid(), Name = "Smartphone" } };
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(Guid id)
        {
            var product = Products.Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}