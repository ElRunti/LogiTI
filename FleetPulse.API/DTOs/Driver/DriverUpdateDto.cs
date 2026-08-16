namespace FleetPulse.API.DTOs.Driver;

public class DriverUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
