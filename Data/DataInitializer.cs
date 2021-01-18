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
            SeedVaccines(dbContext);
        }

        private static void SeedVaccines(ApplicationDbContext dbContext)
        {
            var vaccine = dbContext.Vaccines.FirstOrDefault(r => r.Name ==
                                                                 "COVID-19 Vaccine AstraZeneca");
            if (vaccine == null)
            {
                dbContext.Vaccines.Add(new Vaccine
                {
                    EuOKStatus = null,
                    Name = "COVID-19 Vaccine AstraZeneca",
                    Supplier = "AstraZeneca och Oxford University",
                    VaccineType = Vaccine.Type.Vector
                });
            }

            vaccine = dbContext.Vaccines.FirstOrDefault(r => r.Name == "Comirnaty");
            if (vaccine == null)
                dbContext.Vaccines.Add(new Vaccine
                {
                    Supplier = "Pfizer/BioNTech",
                    Name = "Comirnaty",
                    EuOKStatus = new DateTime(2020,12,21),
                    VaccineType = Vaccine.Type.mRNA
                });

            vaccine = dbContext.Vaccines.FirstOrDefault(r => r.Name == "Covid-19 Vaccine Moderna");
            if (vaccine == null)
                dbContext.Vaccines.Add(new Vaccine
                {
                    Supplier = "Moderna",
                    Name = "Covid-19 Vaccine Moderna",
                    EuOKStatus = new DateTime(2021, 1, 6),
                    VaccineType = Vaccine.Type.mRNA
                });

            dbContext.SaveChanges();
        }
    }
}
