using System.ComponentModel.DataAnnotations;

namespace FleetPulse.API.Models
{
    public class Customer
    {
        [Key]
        public int IdCustomer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }


        //Property navegation to the Package entity
        public ICollection<Package> Packages { get; set; }
    }
}
