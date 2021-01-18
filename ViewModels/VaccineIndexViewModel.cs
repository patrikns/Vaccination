using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vaccination.ViewModels
{
    public class VaccineIndexViewModel
    {
        public List<VaccineViewModel> Vaccines { get; set; } = new List<VaccineViewModel>();
    }

    public class VaccineViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Supplier { get; set; }
    }
}
