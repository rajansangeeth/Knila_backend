using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Diagnostics.Metrics;

namespace Backend.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    Id=1,
                    FirstName="Subbu",
                    LastName="Mani",
                    Email="subbu@gmail.com",
                    PhoneNumber="8685848789",
                    City="Madurai",
                    Country="India",
                    State="Tamil Nadu",
                    PostalCode=640110
                },
                new Contact
                {
                    Id = 2,
                    FirstName = "Suresh",
                    LastName = "Kumar",
                    Email = "harishkumar@gmail.com",
                    PhoneNumber = "8458123000",
                    City = "Karaikudi",
                    Country = "India",
                    State = "Tamil Nadu",
                    PostalCode = 630110,
                    Address="5th street Sekkalai"
                },
                new Contact
                {
                    Id = 3,
                    FirstName = "Karthi",
                    LastName = "Prabhu",
                    Email = "kprabhu@gmail.com",
                    PhoneNumber = "7584869510",
                    City = "Erode",
                    Country = "India",
                    State = "Tamil Nadu",
                    PostalCode = 660110
                }
            );
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }

        
    }
}
