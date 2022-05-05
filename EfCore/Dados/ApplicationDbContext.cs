using Microsoft.EntityFrameworkCore;
using Dominio.Entity;

namespace Dados
{
    public class ApplicationDbContext : DbContext
    {
       
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
       {
       
       }

       //Fluent API to manager table of the database..after run cli to update database
       public override void OnModelCreating(ModelBuilder modelBuilder)
       {
           //example (change the name of of column)
           //modelBuilder.Entity<Product>.Property(p => p.categoryid).HasColumnName("IdCategory");
       }
       
    public DbSet<Category> category { get; set; }
    public DbSet<Product> product { get; set; }
      
    }
}