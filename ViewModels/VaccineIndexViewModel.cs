using System.Collections.Generic;
using Vaccination.Data;

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
        public Supplier Supplier { get; set; }
    }
}
