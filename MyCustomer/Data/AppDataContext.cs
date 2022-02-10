using MyCustomer.Models;
using Microsoft.EntityFrameworkCore;

namespace MyCustomer.Data
{
    public class AppDataContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");

    }
}