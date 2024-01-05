using CRUD.Data.MySQL.Data;
using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using CRUD.Services.Validator;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Services
{
    public class LeadsRepository : ILeadsRepository
    {
        private readonly ProductContext _context;
        private readonly IValidator<Leads> _validator;
        public LeadsRepository(ProductContext context , IValidator<Leads> validator)
        {
            _context = context;
            _validator = validator;
        }
        private void Save()
        {
            try
            {
                 _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception for further investigation
                Console.WriteLine($"Database save failed: {ex.Message}");
                throw; // Re-throw the exception to propagate it further
            }
        }
        public async Task LeadsAdd(Leads model)
        { 
           
            var validationResult = await _validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
              
                var errors = validationResult.Errors.Select(error => error.ErrorMessage);
               
                throw new ValidationException($"Validation failed: {string.Join(", ", errors)}");
            }
            model.IsOpportunity = false;
            await _context.Leads.AddAsync(model);
             Save();
        }


        public async Task<IEnumerable<Leads>> GetAll()
        {
            return await _context.Leads
                .Where(lead => !lead.IsOpportunity)
                .ToListAsync();
        }


        public Leads GetById(int id)
        {
            return  _context.Leads.FirstOrDefault(x => x.LeadsId == id);
        }

            public async Task EditLeads(int id, Leads model)
            {

                var existingLead = await _context.Leads.FindAsync(id);

                if (existingLead == null)
                {
                    throw new InvalidOperationException("Lead not found");
                }

                existingLead.UserId = model.UserId;
                existingLead.AccountType = model.AccountType;
                existingLead.Status = model.Status;
                existingLead.ProjectName = model.ProjectName;
                existingLead.IsOpportunity = model.IsOpportunity;
                existingLead.UpdatedBy = model.UpdatedBy;
                existingLead.UpdatedDate = DateTime.Now;

                var validationResult = await _validator.ValidateAsync(existingLead);

                if (!validationResult.IsValid && existingLead.CreatedBy == null)
                {
                    var errors = validationResult.Errors.Select(error => error.ErrorMessage);
                    throw new ValidationException($"Validation failed: {string.Join(", ", errors)}");
                }

          
                Save();
            }

    }
}
