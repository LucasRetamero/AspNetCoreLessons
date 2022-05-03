using Microsoft.EntityFrameworkCore;
using Dominio.Entity;

namespace Dados
{
    public class ApplicationDbContext : DbContext
    {
       
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
       {
       
       }
       
    public DbSet<Category> category { get; set; }
    public DbSet<Product> product { get; set; }
      
    }
}