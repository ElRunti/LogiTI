namespace FleetPulse.API.DTOs.Driver;

public class DriverCreateDto
{
 
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
