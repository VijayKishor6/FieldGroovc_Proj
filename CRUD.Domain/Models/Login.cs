using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Models
{
    public class Login
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username).NotEmpty().EmailAddress(); 

            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
