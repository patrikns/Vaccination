using System.Collections.Generic;
using System.Security.AccessControl;
using Vaccination.Data;

namespace Vaccination.ViewModels
{
    public class VaccineIndexViewModel
    {
        public string q { get; set; }
        public List<VaccineViewModel> Vaccines { get; set; } = new List<VaccineViewModel>();
    }

    public class VaccineViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Supplier { get; set; }
    }
}
