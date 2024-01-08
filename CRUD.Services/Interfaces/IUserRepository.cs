using CRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Interfaces
{
    public interface IUserRepository
    {
        Task UserAdd(Users model);
        Users GetUserByEmail(string email);
        Task UpdateUser(Users user);
        Users GetById(int id);
    }
}
