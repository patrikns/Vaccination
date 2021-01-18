using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vaccination.Data;
using Vaccination.ViewModels;

namespace Vaccination.Controllers
{
    public class VaccineController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public VaccineController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var viewModel = new VaccineIndexViewModel();

            viewModel.Vaccines = _dbContext.Vaccines.Select(dbVacc => new VaccineViewModel
            {
                Id = dbVacc.Id,
                Supplier = dbVacc.Supplier,
                Name = dbVacc.Name
            }).ToList();
            
            return View(viewModel);
        }
    }
}
