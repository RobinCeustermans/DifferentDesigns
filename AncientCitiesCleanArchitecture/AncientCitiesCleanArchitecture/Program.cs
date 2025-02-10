using AncientCities.Application.AncientCity;
using AncientCities.Application.AncientCity.Commands;
using AncientCities.Application.AncientCity.Queries;
using AncientCities.Application.AncientCityImage;
using AncientCities.Application.AncientCityImage.Commands;
using AncientCities.Application.AncientCityImage.Queries;
using AncientCities.Application.AncientCityType;
using AncientCities.Application.AncientCityType.Commands;
using AncientCities.Application.AncientCityType.Queries;
using AncientCities.Application.CommonData.Factories;
using AncientCities.Application.CommonData.Interfaces;
using AncientCities.Domain.Interfaces.Data;
using AncientCities.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc();

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

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

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.UseRouting();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=City}/{action=Index}");
app.Run();
