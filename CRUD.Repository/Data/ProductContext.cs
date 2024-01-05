using CRUD.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data.MySQL.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Register> Register { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Leads> Leads { get; set; }
        public DbSet<Estimates>Estimates { get; set; }  

    }
}
