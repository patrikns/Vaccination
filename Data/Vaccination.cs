using System;

namespace Vaccination.Data
{
    public class Vaccination
    {
        public int Id { get; set; }
        public Vaccine Vaccine { get; set; }
        public DateTime Timestamp { get; set; }
        public string Clinic { get; set; }

    }
}
