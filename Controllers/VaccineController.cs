using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
                .Where(r=>q==null||r.Name.Contains(q) || r.Supplier.Name.Contains(q))
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
            viewModel.AllSuppliers = GetSupplierListItems();

            return View(viewModel);
        }
        
        [HttpPost]
        public IActionResult New(VaccineNewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dbVaccine = new Vaccine();
                _dbContext.Vaccines.Add(dbVaccine);

                dbVaccine.Supplier = _dbContext.Suppliers
                    .First(r => r.Id == viewModel.SelectedSupplierID);
                dbVaccine.VaccineType = (Vaccine.Type)viewModel.Type;
                dbVaccine.EuOKStatus = viewModel.EuOkStatus;
                dbVaccine.Name = viewModel.Name;
                dbVaccine.AntalDoser = viewModel.AntalDoser;
                dbVaccine.Comment = viewModel.Comment;
                _dbContext.SaveChanges();
            
                return RedirectToAction("Index");
            }

            viewModel.Types = GetTypeSelectListItems();
            viewModel.AllSuppliers = GetSupplierListItems();
            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var viewModel = new VaccineEditViewModel();

            var dbVaccine = _dbContext.Vaccines.Include(p=>p.Supplier)
                .First(r => r.Id == id);

            viewModel.Id = dbVaccine.Id;
            viewModel.SelectedSupplierID = dbVaccine.Supplier.Id;
            viewModel.AllSuppliers = GetSupplierListItems();
            viewModel.Type = (int)dbVaccine.VaccineType;
            viewModel.Types = GetTypeSelectListItems();
            viewModel.EuOkStatus = dbVaccine.EuOKStatus;
            viewModel.Name = dbVaccine.Name;
            viewModel.AntalDoser = dbVaccine.AntalDoser;
            viewModel.Comment = dbVaccine.Comment;

            viewModel.IsActive = true;

            return View(viewModel);
        }

        private List<SelectListItem> GetSupplierListItems()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem
            {
                Value = "0", Text = "Select item..."
            });

            list.AddRange(_dbContext.Suppliers
                .Select(r=>new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = r.Name
                }));
            return list;
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
                dbVaccine.VaccineType = (Vaccine.Type)viewModel.Type;
                dbVaccine.EuOKStatus = viewModel.EuOkStatus;
                dbVaccine.Name = viewModel.Name;
                dbVaccine.AntalDoser = viewModel.AntalDoser;
                dbVaccine.Comment = viewModel.Comment;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            viewModel.Types = GetTypeSelectListItems();
            viewModel.AllSuppliers = GetSupplierListItems();
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
