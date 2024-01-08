using CRUD.Data.MySQL.Data;
using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly ProductContext _context;
        private readonly IValidator<Users> _validator;
        public UserRepository(ProductContext context , IValidator<Users> validator)
        {
            _context = context;
            _validator = validator;
        }
        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task UserAdd(Users model)
        {
            var validationResult = _validator.Validate(model);

            if (!validationResult.IsValid)
            {
              
                var errors = validationResult.Errors.Select(error => error.ErrorMessage);
               
                throw new ValidationException($"Validation failed: {string.Join(", ", errors)}");
            }
            model.IsActive = false;
            model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
            await _context.Users.AddAsync(model);
            await Save();
        }

        public Users GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public async Task UpdateUser(Users user)
        {
            _context.Users.Update(user);
            await Save();
        }

        public Users GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.UserId == id);
        }

    }
}
