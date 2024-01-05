using CRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Interfaces
{
    public interface IEstimatesRepository
    {
        public string EstimateAdd(Estimates model);
        string LockTheEstimate(string id);
        string ChangeTheDefaultEstimate(string id);
    }
}
