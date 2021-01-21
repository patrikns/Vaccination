using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vaccination.Data
{
    public class Vaccine
    {
        public int Id { get; set; }
        public enum Type
        {
            Unknown,
            mRNA,
            Vector
        }
        public Supplier Supplier { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime? EuOKStatus { get; set; }
        public Type VaccineType { get; set; }


        public string Comment { get; set; }
        public int AntalDoser { get; set; }
    }
}
