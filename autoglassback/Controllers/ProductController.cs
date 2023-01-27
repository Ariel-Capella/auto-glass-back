using autoglassback.Context;
using autoglassback.Models;
using Microsoft.AspNetCore.Mvc;

namespace autoglassback.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _Product;

        public ProductController(ProductContext productContext)
        {
            productContext.Set<Product>();
            _Product = productContext;
        }

        [HttpGet("GetProducts")]
        public IEnumerable<Product> GetProducts()
        {
                List<Product> products = _Product.Products.ToList();
                return products;
        }

        [HttpPost("AddProduct/{dataValidade}")]
        public IActionResult CreateProduct([FromRoute] DateTime dataValidade)
        {
            if (dataValidade < DateTime.Now)
                return Ok(StatusCode(400));
            var product = new Product(dataValidade);
            _Product.Add(product);
            _Product.SaveChanges();
            return Ok(StatusCode(200));
        }

        [HttpPost("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody] int id)
        {
            var product = await _Product.Products.FindAsync(id);
            if (product != null)
            {
                product.Situacao = "inativo";
                _Product.Products.Update(product);
                _Product.SaveChanges();
                return Ok(StatusCode(200));
            }
            return Ok(StatusCode(404));
        }

        [HttpPost("RecoverProduct")]
        public async Task<IActionResult> RecoverProduct([FromBody] int id)
        {
            var product = await _Product.Products.FindAsync(id);
            if (product != null)
            {
                product.Situacao = "ativo";
                _Product.Products.Update(product);
                _Product.SaveChanges();
                return Ok(StatusCode(200));
            }
            return Ok(StatusCode(404));
        }
    }
}