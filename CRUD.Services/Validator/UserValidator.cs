using CRUD.Data.MySQL.Data;
using CRUD.Domain.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CRUD.Services.Validator
{
    public class UserValidator : AbstractValidator<Users>
    {
        private readonly ProductContext context;
        public UserValidator() { }
        public UserValidator(ProductContext _context)
        {
            context = _context;
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(30).WithMessage("Name cannot exceed 100 characters");

            RuleFor(user => user.Email).Must(BeUniqueEmail).WithMessage("Email Address Already Exsits")
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Valid email address is required");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
           .Must(password => Regex.IsMatch(password, @"[a-z]")).WithMessage("Password must contain at least one lowercase letter")
           .Must(password => Regex.IsMatch(password, @"[A-Z]")).WithMessage("Password must contain at least one uppercase letter")
           .Must(password => Regex.IsMatch(password, @"\d")).WithMessage("Password must contain at least one digit");
          //.Must(password => Regex.IsMatch(password, @"[^\da-zA-Z]")).WithMessage("Password must contain at least one special character");

            RuleFor(user => user.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required")
                .Matches(@"^\d{10}$").WithMessage("Invalid phone number format");

            // Additional rules for other properties

            RuleFor(user => user.CreatedBy)
                .NotEmpty().WithMessage("CreatedBy is required")
                .MaximumLength(50).WithMessage("CreatedBy cannot exceed 50 characters");

            RuleFor(user => user.UpdatedBy)
                .NotEmpty().WithMessage("UpdatedBy is required")
                .MaximumLength(50).WithMessage("UpdatedBy cannot exceed 50 characters");

            RuleFor(user => user.CreatedDate)
                .NotEmpty().WithMessage("CreatedDate is required");

            RuleFor(user => user.UpdatedDate)
                .NotEmpty().WithMessage("UpdatedDate is required");

            // Add more validation rules as needed for other properties
        }
        private bool BeUniqueEmail(string email)
        {
            // Check if the email already exists in the database
            return !context.Users.Any(u => u.Email == email);
        }
       
    }
}
