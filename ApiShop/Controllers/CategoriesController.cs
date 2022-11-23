using ApiShop.Models;
using ApiShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesService _categoryService;

        public CategoriesController(CategoriesService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Category>>> Get()
        {
            var listOfCategories = await _categoryService.FindAllAsync();
            if (listOfCategories is null)
            {
                return NotFound("The list is void");
            }
            return listOfCategories;
        }

        [HttpGet("Products")]
        public async Task<ActionResult<ICollection<Category>>> GetAllWithCategories()
        {
            var listOfCategories = await _categoryService.FindAllWithCategoriesAsync();
            if (listOfCategories is null)
            {
                return NotFound("The list is void");
            }
            return listOfCategories;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Category category)
        {
            try
            {
                var newCategory = await _categoryService.CreateAsync(category);
                return Ok(newCategory);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Category category)
        {
            try
            {
                var newCategory = await _categoryService.UpdateAsync(id, category);
                return Ok(newCategory);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var category = await _categoryService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
