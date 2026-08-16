using FleetPulse.API.DTOs.Customer;
using FleetPulse.API.Models;

namespace FleetPulse.API.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Driver, DriverDto>();
        }
    }
}
