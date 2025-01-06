using AncientCities.Application.Interfaces;
using AncientCities.Application.Interfaces.Services;
using AncientCities.Application.Mappers;
using AncientCities.Application.Services;
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

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICityTypeService, CityTypeService>();
builder.Services.AddScoped<ICityImageService, CityImageService>();
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
