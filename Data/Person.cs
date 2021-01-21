using System.Collections.Generic;

namespace Vaccination.Data
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PersonalNumber { get; set; }
        public string EmailAddress { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }

        public List<Vaccination> Vaccinations { get; set; }
    }
}
