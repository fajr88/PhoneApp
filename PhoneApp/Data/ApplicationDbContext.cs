using Microsoft.EntityFrameworkCore;
using PhoneApp.Entities;

namespace PhoneApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Contact>().HasData(
                new Contact { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Phone = "1234567890" },
                new Contact { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Phone = "0987654321" }
            );
        }
    }
}