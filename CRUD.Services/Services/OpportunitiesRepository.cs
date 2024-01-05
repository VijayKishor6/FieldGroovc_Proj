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
    public class OpportunitiesRepository : IOpportunities
    {

        private readonly ProductContext _context;
        private readonly IValidator<Leads> _validator;
        public OpportunitiesRepository(ProductContext context, IValidator<Leads> validator)
        {
            _context = context;
            _validator = validator;
        }
        private async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception for further investigation
                Console.WriteLine($"Database save failed: {ex.Message}");
                throw; // Re-throw the exception to propagate it further
            }
        }
        public async Task ConvertToOpportunities(int id)
        {
            var details = _context.Leads.FirstOrDefault(x => x.LeadsId == id);
            if (details != null)
            {
                details.IsOpportunity = true;
                await Save();

            }
        }

        public async Task<IEnumerable<Leads>> GetAll()
        {
            return await _context.Leads
                .Where(lead => lead.IsOpportunity)
                .ToListAsync();
        }


        public async Task OpportunitiesAdd(Leads model)
        {

            var validationResult = await _validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {

                var errors = validationResult.Errors.Select(error => error.ErrorMessage);

                throw new ValidationException($"Validation failed: {string.Join(", ", errors)}");
            }
            model.IsOpportunity = true;
            await _context.Leads.AddAsync(model);
            await Save();
        }
    }
}
