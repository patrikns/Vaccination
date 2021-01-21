using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Vaccination.ViewModels
{
    public class VaccineNewViewModel
    {
        [MaxLength(100)]
        public string Supplier { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime? EuOkStatus { get; set; }

        public int Type { get; set; }

        public List<SelectListItem> Types { get; set; } = new List<SelectListItem>();
    }
}