using ApiShop.Context;
using ApiShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiShop.Services
{
    public class SellersService
    {
        private readonly AppDbContext _context;

        public SellersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateAsync(Seller seller)
        {
           var obj = _context.Sellers.FirstOrDefault(p => p.Email== seller.Email);
            if (obj == null)
            {
                _context.Sellers.Add(seller);
                await _context.SaveChangesAsync();
                return "Seller created!";
            }
            throw new Exception("E-mail already registered!");
        }

        public async Task<Seller> UpdateAsync(int id, Seller seller)
        {
            if (id != seller.SellerId)
            {
                throw new Exception("Id does not match user!");
            }

            var obj = _context.Sellers.AsNoTracking().FirstOrDefault(p => p.SellerId == id);

            if (obj == null)
            {
                throw new Exception("User not found!");
            }
            if(seller.Email != obj.Email)
            {
                throw new Exception("Email cannot be changed!");
            }
            _context.Entry(seller).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return seller;
        }

        public async Task<string> DeleteAsync(string email, string passwd)
        {
            var obj = _context.Sellers.FirstOrDefault(p => p.Email == email && p.Password == passwd);
            if (obj == null)
            {
                throw new Exception("Email or password incorrect!");
            }
            _context.Remove(obj);
            await _context.SaveChangesAsync();
            return "Account deleted!";
        }
    }
}
