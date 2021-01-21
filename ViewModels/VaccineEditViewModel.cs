using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vaccination.Data;

namespace Vaccination.ViewModels
{
    public class VaccineEditViewModel
    {
        public int Id { get; set; }

        public int SelectedSupplierID { get; set; }
        public List<SelectListItem> AllSuppliers { get; set; } = new List<SelectListItem>();

        public int Type { get; set; }
        public List<SelectListItem> Types { get; set; } = new List<SelectListItem>();

        [MaxLength(100)]
        public Supplier Supplier { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EuOkStatus { get; set; }

        public string Comment { get; set; }
        [Range(1,1000)]
        public int AntalDoser { get; set; }

        public bool IsActive { get; set; }
    }
}