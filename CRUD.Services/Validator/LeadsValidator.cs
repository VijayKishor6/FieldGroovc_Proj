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
    public class LeadsValidator : AbstractValidator<Leads>
    {
        private readonly ProductContext context;
        public LeadsValidator() 
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is Must...");
            RuleFor(x => x.AccountType)
             .NotEmpty()
             .MaximumLength(255)
             .Matches("^[a-zA-Z]*$").WithMessage("AccountType should only contain alphabet characters");

            RuleFor(x => x.Status)
                .NotEmpty()
                .MaximumLength(255)
                .Matches("^[a-zA-Z]*$").WithMessage("Status should only contain alphabet characters");

            RuleFor(x => x.ProjectName)
                .NotEmpty()
                .MaximumLength(255)
                .Matches("^[a-zA-Z]*$").WithMessage("ProjectName should only contain alphabet characters");

           

            RuleFor(x => x.UpdatedBy)
                .MaximumLength(255)
                .Matches("^[a-zA-Z]*$").WithMessage("UpdatedBy should only contain alphabet characters");

        }


    }
}
