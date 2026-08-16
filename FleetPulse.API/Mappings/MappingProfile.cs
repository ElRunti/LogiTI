using FleetPulse.API.DTOs.Customer;
using FleetPulse.API.DTOs.Delivery;
using FleetPulse.API.DTOs.Driver;
using FleetPulse.API.DTOs.Package;
using FleetPulse.API.Models;

namespace FleetPulse.API.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            //Customer mappings
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>();
            //Package mappings
            CreateMap<Package, PackageDto>();
            CreateMap<PackageCreateDto, Package>();
            CreateMap<PackageUpdateDto, Package>();
            //Driver mappings
            CreateMap<Driver, DriverDto>();
            CreateMap<DriverUpdateDto, Driver>();
            CreateMap<DriverCreateDto, Driver>();
            //Delivery mappings
            CreateMap<Delivery, DeliveryDto>();
            CreateMap<DeliveryCreateDto, Delivery>();
            CreateMap<DeliveryUpdateDto, Delivery>();
        }
    }
}
