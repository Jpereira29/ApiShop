using ApiShop.Models;
using ApiShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService _productService;

        public ProductsController(ProductsService productService)
        {
            _productService = productService;

        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Product>>> Get()
        {
            try
            {
                var products = await _productService.FindAllAsync();
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ICollection<Product>>> Get(int id)
        {
            try
            {
                var products = await _productService.FindCategoryAsync(id);
                return Ok(products);
            }
            catch (Exception e)
            {
                return StatusCode(204, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            try
            {
                return Ok(await _productService.CreateAsync(product));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> Put(int id, Product product)
        {
            try
            {
                return Ok(await _productService.UpdateAsync(id, product));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<ActionResult<Product>> Delete(int id, Seller seller)
        {
            try
            {
                return Ok(await _productService.DeleteAsync(id, seller));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
