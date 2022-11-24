using ApiShop.Context;
using ApiShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiShop.Services
{
    public class ProductsService
    {
        private readonly AppDbContext _context;

        public ProductsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> FindAllAsync()
        {
            var products = await _context.Products.ToListAsync();
            if (products is null)
            {
                throw new Exception("No products registred!");
            }
            return products;
        }

        public async Task<List<Product>> FindCategoryAsync(int id)
        {
            var products = _context.Products.Where(p => p.CategoryId == id);
            if (products.Count() == 0)
            {
                throw new Exception("No content!");
            }
            return await products.ToListAsync();
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(int id, Product product)
        {
            var obj = _context.Products.AsNoTracking().FirstOrDefault(p => p.ProductId == product.ProductId);

            if (id != product.ProductId ||
                obj is null)
            {
                throw new Exception("Product not found!");
            }
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<string> DeleteAsync(int id, Seller seller)
        {
            var obj = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (obj == null)
            {
                throw new Exception("Product not found!");
            }
            if (obj.SellerId == seller.SellerId)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
                return "Product deleted!";
            }
            return "Ivalid data!";
        }
    }
}
