using Microsoft.EntityFrameworkCore;
using aspentity.Models;
namespace aspentity.Database
{
    public class applicationDBContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios {get; set;}

        public applicationDBContext(DbContextOptions<applicationDBContext> option) : base(option) {}
    }
}