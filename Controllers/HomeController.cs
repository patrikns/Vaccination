using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using Vaccination.Data;
using Vaccination.Models;
using Vaccination.ViewModels;

namespace Vaccination.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel();
            viewModel.AntalGjordaVaccineringar = _dbContext.Vaccinations.Count();
            viewModel.AntalGodkandaVaccin = _dbContext.Vaccines.Count(r=>r.EuOKStatus != null);
            viewModel.NumberOfPersons = _dbContext.Persons.Count();
            viewModel.NumberOfSuppliers = _dbContext.Suppliers.Count();
            var senast = _dbContext.Vaccines.OrderByDescending(r => r.EuOKStatus).Take(1).First();
            viewModel.SenastGodkand = senast.EuOKStatus.Value;
            viewModel.SenastGodkandVaccin = senast.Name;
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
