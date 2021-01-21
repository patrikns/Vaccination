using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Index(string q)
        {
            var viewModel = new VaccineIndexViewModel();

            viewModel.Vaccines = _dbContext.Vaccines
                .Where(r=>q==null||r.Name.Contains(q))
                .Select(dbVacc => new VaccineViewModel
            {
                Id = dbVacc.Id,
                Supplier = dbVacc.Supplier.Name,
                Name = dbVacc.Name
            }).ToList();
            
            return View(viewModel);
        }

        public IActionResult New()
        {
            var viewModel = new VaccineNewViewModel();
            viewModel.Types = GetTypeSelectListItems();
            

            return View(viewModel);
        }

        public IActionResult Edit(int Id)
        {
            var viewModel = new VaccineEditViewModel();

            var dbVaccine = _dbContext.Vaccines.Include(p=>p.Supplier).First(r => r.Id == Id);

            viewModel.Id = dbVaccine.Id;
            viewModel.EuOkStatus = dbVaccine.EuOKStatus;
            viewModel.Name = dbVaccine.Name;
            viewModel.SelectedSupplierID = dbVaccine.Supplier.Id;
            viewModel.AllSuppliers = GetSupplierListItems();
            viewModel.Type = (int)dbVaccine.VaccineType;
            viewModel.Types = GetTypeSelectListItems();
            viewModel.AntalDoser = dbVaccine.AntalDoser;
            viewModel.Comment = dbVaccine.Comment;

            return View(viewModel);
        }

        private List<SelectListItem> GetSupplierListItems()
        {
            
            return null;
        }

        [HttpPost]
        public IActionResult Edit(int id, VaccineEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dbVaccine = _dbContext.Vaccines
                    .Include(p => p.Supplier)
                    .First(r => r.Id == id);

                dbVaccine.Supplier = _dbContext.Suppliers
                    .First(r => r.Id == viewModel.SelectedSupplierID);
                
                dbVaccine.EuOKStatus = viewModel.EuOkStatus;
                dbVaccine.Name = viewModel.Name;
                dbVaccine.AntalDoser = viewModel.AntalDoser;
                dbVaccine.Comment = viewModel.Comment;
                _dbContext.SaveChanges();
            
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
        
        List<SelectListItem> GetTypeSelectListItems()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem("Okänd", "0"));
            list.Add(new SelectListItem("mRNA", "1"));
            list.Add(new SelectListItem("Vector", "2"));
            return list;
        }
    }
}
