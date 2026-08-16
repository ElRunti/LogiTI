namespace FleetPulse.API.DTOs.Driver;

public class DriverDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
