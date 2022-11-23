using ApiShop.Context;
using ApiShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiShop.Services
{
    public class CategoriesService
    {
        private readonly AppDbContext _context;

        public CategoriesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> FindAllAsync()
        {
            var categorys = _context.Categories.ToListAsync();
            return await categorys;
        }

        public async Task<List<Category>> FindAllWithCategoriesAsync()
        {
            var categorys = _context.Categories
                .Include(p => p.Products)
                .OrderBy(p => p.Name)
                .ToListAsync();
            return await categorys;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            var obj = _context.Categories.FirstOrDefault(p => p.Name == category.Name);
            if (obj != null)
            {
                throw new Exception("this category already exists!");
            }
            _context.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(int id, Category category)
        {
            var obj = _context.Categories.AsNoTracking().FirstOrDefault(p => p.CategoryId == category.CategoryId);

            if (id != category.CategoryId ||
                obj is null)
            {
                throw new Exception("Category not found!");
            }
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteAsync(int id)
        {
            var obj = _context.Categories
                .Include(p => p.Products)
                .ToList()
                .FirstOrDefault(p => p.CategoryId == id);

            if (obj is null)
            {
                throw new Exception("Category not found!");
            }
            if (obj.Products.Count > 0)
            {
                throw new Exception("This category cannot be deleted because it has products!");
            }
            _context.Categories.Remove(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
