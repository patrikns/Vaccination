using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Vaccination.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
    }
}
