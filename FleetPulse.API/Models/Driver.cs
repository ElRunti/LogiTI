using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace FleetPulse.API.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // Property navegation to the Package entity
        public ICollection<Package> Packages { get; set; }

    }
}
