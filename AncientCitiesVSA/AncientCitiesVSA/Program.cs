using AncientCitiesVSA.Features.CityType.DeleteCityType;
using AncientCitiesVSA.Features.CityType.GetCityTypeById;
using AncientCitiesVSA.Features.CityType.GetCityTypes;
using AncientCitiesVSA.Features.CityType.UpsertCityType;
using AncientCitiesVSA.Infrastructure;
using Features.CityType.Repositories.Abstract;
using Features.CityType.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMvc();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IGetCityTypesHandler, GetCityTypesHandler>();
builder.Services.AddScoped<IGetCityTypeByIdHandler, GetCityTypeByIdHandler>();
builder.Services.AddScoped<IUpsertCityTypeHandler, UpsertCityTypeHandler>();
builder.Services.AddScoped<IDeleteCityTypeHandler, DeleteCityTypeHandler>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ICityTypeRepository, CityTypeRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CityType}/{action=Index}/{id?}");

app.Run();