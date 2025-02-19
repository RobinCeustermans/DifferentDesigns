using AncientCities.Application.Factories;
using AncientCities.Application.Interfaces;
using AncientCities.Application.Mappers;
using AncientCities.Application.UseCases.City.Commands;
using AncientCities.Application.UseCases.City.Queries;
using AncientCities.Application.UseCases.CityImage.Commands;
using AncientCities.Application.UseCases.CityImage.Queries;
using AncientCities.Application.UseCases.CityType.Commands;
using AncientCities.Application.UseCases.CityType.Queries;
using AncientCities.Domain.Common.Interfaces;
using AncientCities.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IQueryCommandFactory, QueryCommandFactory>();

builder.Services.AddScoped<GetAllCityTypesQuery>();
builder.Services.AddScoped<GetCityTypeByIdQuery>();
builder.Services.AddScoped<UpsertCityTypeCommand>();
builder.Services.AddScoped<DeleteCityTypeCommand>();

builder.Services.AddScoped<GetCityImageByIdQuery>();
builder.Services.AddScoped<DeleteCityImageCommand>();

builder.Services.AddScoped<GetAllCitiesQuery>();
builder.Services.AddScoped<GetCityByIdQuery>();
builder.Services.AddScoped<UpsertCityCommand>();
builder.Services.AddScoped<DeleteCityCommand>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(CityMapper));
builder.Services.AddAutoMapper(typeof(CityTypeMapper));
builder.Services.AddAutoMapper(typeof(CityImageMapper));

var app = builder.Build();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=City}/{action=Index}");

app.Run();
