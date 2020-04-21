using Microsoft.EntityFrameworkCore;
using aspentity.Models;
namespace aspentity.Database
{
    public class applicationDBContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios {get; set;}
        public DbSet<Categoria> Categorias {get; set;}
        public DbSet<Produto> Produtos {get; set;}

        public applicationDBContext(DbContextOptions<applicationDBContext> option) : base(option) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("ProdutosLoja");
            modelBuilder.Entity<Produto>().Property(p => p.Nome).HasMaxLength(100);
            modelBuilder.Entity<Produto>().Property(p => p.Nome).IsRequired();
        }
    }
}