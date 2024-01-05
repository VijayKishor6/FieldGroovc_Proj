using CRUD.Data.MySQL.Data;
using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Services
{
    public class EstimatesRepository: IEstimatesRepository
    {
        private readonly ProductContext _context;
        private readonly LeadsRepository _leadsRepository;

        public EstimatesRepository(ProductContext context, LeadsRepository leadsRepository)
        {
            _context = context;
            _leadsRepository = leadsRepository;
        }
        private void Save()
        {
            _context.SaveChanges();
        }
        public string EstimateAdd(Estimates model)
        {
            try
            {
                var ConvertTheEstimate = _leadsRepository.GetById(model.LeadsId);
                if (ConvertTheEstimate.IsOpportunity == true)
                {
                    model.Locked = false;
                    model.DefaultEstimate = false;
                    if (model.Status == Status.ReadyForWorkOrder)
                    {
                        model.ReadyForWorkOrder = true;
                        _context.Estimates.Add(model);
                        Save();
                        return "added successfully...!";
                    }
                    else { 
                    _context.Estimates.Add(model);
                    Save();
                    return "added successfully...!";
                    }
                }
                else
                {
                    return "You can create estimate only for Opportunity";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string ChangeTheDefaultEstimate(string id)
        {
            Estimates DefaultEstimate = _context.Estimates.FirstOrDefault(x => x.EstimateId == id);

            if (DefaultEstimate != null && DefaultEstimate.Locked == false)
            {
                DefaultEstimate.DefaultEstimate = true;
                _context.SaveChanges();
                return "Default Estimate Changed";
            }
            else
            {
                return "Default Estimate not changed because of locked";
            }
        }


        public string LockTheEstimate(string id)
        {
            Estimates lockedEstimate = _context.Estimates.FirstOrDefault(x => x.EstimateId == id);

            if (lockedEstimate != null)
            {
                lockedEstimate.Locked = true;
                _context.SaveChanges();
                return "Estimate Blocked";
            }
            else
            {
                return "Estimate not found";
            }
        }
    }
}
