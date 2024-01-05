using CRUD.Domain.Models;

namespace CRUD.Services.Interfaces
{
    public interface IProductRepository
    {

        
        Task RegisterAdd(Register model);
        bool UserValid( Login model);
        bool EmailValid(string email);
        void UpdatePassword(string email, string password);
    }
}
