using System;

namespace DistributionDapper.Entities
{
    public class Customer
    {
        public int id { get; set;}
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public bool Sex { get; set; }
        public DateTime DateOfbirth { get; set; }
        public string CountryOfResidence { get; set; }
        public string Email { get; set; }
    }
}
