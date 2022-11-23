using ApiShop.Models;
using ApiShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly SellersService _sellerService;

        public SellersController(SellersService sellerService)
        {
            _sellerService = sellerService;

        }

        [HttpPost]
        public async Task<ActionResult> Get(Seller seller)
        {
            try
            {
                return Ok(await _sellerService.CreateAsync(seller));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Seller seller)
        {
            try
            {
                return Ok(await _sellerService.UpdateAsync(id, seller));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(string email, string passwd)
        {
            try
            {
                return Ok(await _sellerService.DeleteAsync(email, passwd));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}