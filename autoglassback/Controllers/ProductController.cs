using autoglassback.Context;
using autoglassback.Models;
using Microsoft.AspNetCore.Mvc;

namespace autoglassback.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        readonly ProductContext Product;

        public ProductController(ProductContext productContext)
        {
            productContext.Set<Product>();
            Product = productContext;
        }

        [HttpGet("GetProducts")]
        public IEnumerable<Product> GetProducts()
        {
            List<Product> products = Product.Products.ToList();
            return products;
        }

        [HttpPost("AddProduct")]
        public IActionResult CreateProduct()
        {
            var product = new Product();
            Product.Add(product);
            Product.SaveChanges();
            return Ok();
        }

        [HttpGet("GetProductById/{id}")]
        public Product GetProductById([FromRoute] int id)
        {
            var response = Product.Products.Where(p => p.CodigoProduto == id).FirstOrDefault();
            if (response != null)
                return response;
            else
                return null;
        }
    }
}