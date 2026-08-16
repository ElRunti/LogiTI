namespace FleetPulse.API.DTOs.Driver;

public class DriverChangePasswordDto
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmNewPassword { get; set; }
}
