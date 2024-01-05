using CRUD.Data.MySQL.Data;
using CRUD.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CRUD.Services.Validator
{
    public class RegisterValidator : AbstractValidator<Register>
    {
        private readonly ProductContext context;

        public RegisterValidator()
        {
        }

        public RegisterValidator(ProductContext _context)
        {
            context = _context;
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").Must(BeValidName).WithMessage("Name can only contain letters"); ;
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required").Matches(@"^[0-9]{10}$").WithMessage("Invalid phone number");
            RuleFor(x => x.Password)
           .NotEmpty().WithMessage("Password is required")
           .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
           .Must(password => Regex.IsMatch(password, @"[a-z]")).WithMessage("Password must contain at least one lowercase letter")
           .Must(password => Regex.IsMatch(password, @"[A-Z]")).WithMessage("Password must contain at least one uppercase letter")
           .Must(password => Regex.IsMatch(password, @"\d")).WithMessage("Password must contain at least one digit")
           .Must(password => Regex.IsMatch(password, @"[^\da-zA-Z]")).WithMessage("Password must contain at least one special character");
            RuleFor(x => x.Email)
           .NotEmpty().WithMessage("Email is required")
           .EmailAddress().WithMessage("Invalid email address")
           .Must(BeUniqueEmail).WithMessage("Email already exists");
        }
        private bool BeUniqueEmail(string email)
        {
            // Check if the email already exists in the database
            return !context.Register.Any(u => u.Email == email);
        }
        private bool BeValidName(string name)
        {

            return Regex.IsMatch(name, "^[a-zA-Z ]+$");
        }
    }
}
