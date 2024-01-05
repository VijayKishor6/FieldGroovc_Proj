using CRUD.Data.MySQL.Data;
using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Services.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    

        public async Task RegisterAdd(Register model)
        {

            model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            await _context.Register.AddAsync(model);
            await Save();
        }
        public bool UserValid(Login model)
        {
            var user = _context.Register.FirstOrDefault(value => value.Email == model.Username);

            if (user != null)
            {
              
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);

                return isPasswordValid;
            }

            return false;
        }

        public bool EmailValid(string email)
        {
            var value = _context.Register.FirstOrDefault(x => x.Email == email);
            if (value == null)
                return false;
            return true;
        }

        public void UpdatePassword(string email, string newPassword)
        {
            var user = _context.Register.FirstOrDefault(x => x.Email == email);

            if (user != null)
            {
                user.Password = newPassword;

                
                _context.SaveChanges();
            }
           
        }

      
    }
}
