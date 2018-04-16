using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
         ProductDetails[] products = new ProductDetails[]
        {
            new ProductDetails { Id = 1, Name = "Milk", Category = "Groceries", Price = 1.65M },
            new ProductDetails { Id = 2, Name = "Cookies", Category = "Groceries", Price = 2.75M },
            new ProductDetails { Id = 3, Name = "Notebook", Category = "Stationary", Price = 5.99M },
            new ProductDetails { Id = 4, Name = "Coffee", Category = "Groceries", Price = 3.99M },
            new ProductDetails { Id = 5, Name = "Cushion", Category = "Homedecore", Price = 12.99M },
            new ProductDetails { Id = 6, Name = "Egg", Category = "Groceries", Price = 2.99M },
            new ProductDetails { Id = 7, Name = "Ball", Category = "Toy", Price = 1.99M }
        };

        [HttpGet]
        public IEnumerable<ProductDetails> GetAllProducts()
        {
            return products;
        }

        [HttpPost]
        public IHttpActionResult GetProduct(int id)
        {
            //var product = products.FirstOrDefault((p) => p.Id == id);
            var product = products.Where(a => a.Id == id).Select(
                x => new
                {
                    x.Id,
                    x.Name
                }).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
