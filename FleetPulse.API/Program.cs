using AutoMapper;
using FleetPulse.API.Data;
using FleetPulse.API.Mappings;
using FleetPulse.API.Repositories.Contracts;
using FleetPulse.API.Repositories.Implementations;
using FleetPulse.API.Services.Contracts;
using FleetPulse.API.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// add DbContext to the service container
builder.Services.AddDbContext<FleetPulseDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("FleetPulseDbConnection")));
//add AutoMapper to the service container
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});

//add Services to the service container
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder .Services.AddScoped<IPackageService, PackageService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();

//add Repositorys to the service container
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();

//don't require UTC format in request 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.WebHost.UseUrls("http://0.0.0.0:8080");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
