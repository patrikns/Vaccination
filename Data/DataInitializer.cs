using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Vaccination.Data
{
    public class DataInitializer
    {
        public static void SeedData(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            dbContext.Database.Migrate();
            SeedSuppliers(dbContext);
            SeedVaccines(dbContext);
        }

        
        private static void SeedSuppliers(ApplicationDbContext dbContext)
        {
            var supplier = dbContext.Suppliers.FirstOrDefault(r => r.Name == "AstraZeneca och Oxford University");
            if (supplier == null)
                dbContext.Suppliers.Add(new Supplier {Name = "AstraZeneca och Oxford University" });

            supplier = dbContext.Suppliers.FirstOrDefault(r => r.Name == "Pfizer/BioNTech");
            if (supplier == null)
                dbContext.Suppliers.Add(new Supplier { Name = "Pfizer/BioNTech" });

            supplier = dbContext.Suppliers.FirstOrDefault(r => r.Name == "Moderna");
            if (supplier == null)
                dbContext.Suppliers.Add(new Supplier { Name = "Moderna" });

            dbContext.SaveChanges();

        }
        private static void SeedVaccines(ApplicationDbContext dbContext)
        {
            var vaccine = dbContext.Vaccines.FirstOrDefault(r => r.Name ==
                                                                 "COVID-19 Vaccine AstraZeneca");
            if (vaccine == null)
            {
                dbContext.Vaccines.Add(new Vaccine
                {
                    Supplier = dbContext.Suppliers.First(r=>r.Name == "AstraZeneca och Oxford University"),
                    Name = "COVID-19 Vaccine AstraZeneca",
                    EuOKStatus = null,
                    VaccineType = Vaccine.Type.Vector
                });
            }
            else
            {
                vaccine.Supplier = dbContext.Suppliers.First(r => r.Name == "AstraZeneca och Oxford University");

            }

            vaccine = dbContext.Vaccines.FirstOrDefault(r => r.Name == "Comirnaty");
            if (vaccine == null)
                dbContext.Vaccines.Add(new Vaccine
                {
                    Supplier = dbContext.Suppliers.First(r=>r.Name == "Pfizer/BioNTech"),
                    Name = "Comirnaty",
                    EuOKStatus = new DateTime(2020,12,21),
                    VaccineType = Vaccine.Type.mRNA
                });
            else
            {
                vaccine.Supplier = dbContext.Suppliers.First(r => r.Name == "Pfizer/BioNTech");
            }

            vaccine = dbContext.Vaccines.FirstOrDefault(r => r.Name == "Covid-19 Vaccine Moderna");
            if (vaccine == null)
                dbContext.Vaccines.Add(new Vaccine
                {
                    Supplier = dbContext.Suppliers.First(r=>r.Name == "Moderna"),
                    Name = "Covid-19 Vaccine Moderna",
                    EuOKStatus = new DateTime(2021, 1, 6),
                    VaccineType = Vaccine.Type.mRNA
                });
            else
            {
                vaccine.Supplier = dbContext.Suppliers.First(r => r.Name == "Moderna");
            }

            dbContext.SaveChanges();
        }
    }
}
