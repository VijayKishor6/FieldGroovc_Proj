using CRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Interfaces
{
    public interface ILeadsRepository
    {
        Task LeadsAdd(Leads model);
        Task<IEnumerable<Leads>> GetAll();
        Leads GetById(int id);
        Task EditLeads(int id , Leads model);    

        // Task<Users> GetUserByEmail(string email);
        // Task UpdateUser(Leads user);
    }
}
