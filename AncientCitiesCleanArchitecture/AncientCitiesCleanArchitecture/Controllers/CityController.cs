using AncientCities.Application.AncientCity;
using AncientCities.Application.AncientCity.Commands;
using AncientCities.Application.AncientCity.Queries;
using AncientCities.Application.AncientCityImage.Commands;
using AncientCities.Application.AncientCityImage.Queries;
using AncientCities.Application.AncientCityType.Queries;
using AncientCities.Application.CommonData;
using AncientCities.Application.CommonData.Interfaces;
using AncientCities.Domain.Entities;
using AncientCities.WebAPI.ViewModels;
using AncientCities.WebAPI.Views.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AncientCities.WebAPI.Controllers
{
    [Controller]
    public class CityController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IQueryCommandFactory _factory;

        public CityController(IWebHostEnvironment webHostEnvironment, IQueryCommandFactory factory)
        {
            _webHostEnvironment = webHostEnvironment;
            _factory = factory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cities = await _factory.Create<GetAllCitiesQuery>().ExecuteAsync();
            return View(cities);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            var typeList = (await _factory.Create<GetAllCityTypesQuery>().ExecuteAsync())
                .Select(cityType => new SelectListItem
                {
                    Value = cityType.Id.ToString(),
                    Text = cityType.Name
                });

            var cityViewModel = new CityViewModel
            {
                CityTypes = typeList,
                City = new CityDto(),
                EraNames = EnumHelper.GetEnumSelectList<Era.EraNames>()
            };

            ViewBag.EraNames = cityViewModel.EraNames;

            if (id != null && id > 0)
            {
                cityViewModel.City = await _factory.Create<GetCityByIdQuery>().ExecuteAsync(id.Value, includeProperties: "CityImages");
                if (cityViewModel.City == null)
                    return NotFound();

                cityViewModel.EraCreatedInt = cityViewModel.City.EraCreated == "BC" ? 0 : 1;
                cityViewModel.EraDefunctInt = cityViewModel.City.EraDefunct == "BC" ? 0 : 1;
            }

            return View(cityViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(CityViewModel cityViewModel, List<IFormFile> files)
        {
            if (!ModelState.IsValid)
            {
                cityViewModel.EraNames = EnumHelper.GetEnumSelectList<Era.EraNames>();
                return View(cityViewModel);
            }

            cityViewModel.City.EraCreated = cityViewModel.EraCreatedInt == 0 ? "BC" : "AD";
            cityViewModel.City.EraDefunct = cityViewModel.EraDefunctInt == 0 ? "BC" : "AD";

            string wwwrootPath = _webHostEnvironment.WebRootPath;

            if (files != null)
            {
                string cityPath = $"images/cities/city-{cityViewModel.City.Id}";
                string finalPath = Path.Combine(wwwrootPath, cityPath);

                if (!Directory.Exists(finalPath))
                {
                    Directory.CreateDirectory(finalPath);
                }

                foreach (IFormFile file in files)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    if (cityViewModel.City.CityImages == null)
                    {
                        cityViewModel.City.CityImages = new List<CityImage>();
                    }

                    cityViewModel.City.CityImages.Add(new CityImage
                    {
                        CityId = cityViewModel.City.Id,
                        ImageUrl = $"/{cityPath}/{fileName}"
                    });
                }
            }

            await _factory.Create<UpsertCityCommand>().ExecuteAsync(cityViewModel.City);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteImage(int imageId)
        {
            var imageToBeDeleted = await _factory.Create<GetCityImageByIdQuery>().ExecuteAsync(imageId);
            if (imageToBeDeleted == null)
                return NotFound();

            string cityPath = $"images/cities/city-{imageToBeDeleted.CityId}";
            string finalPath = Path.Combine(_webHostEnvironment.WebRootPath, cityPath);

            if (Directory.Exists(finalPath))
            {
                Directory.Delete(finalPath, true);
            }

            await _factory.Create<DeleteCityImageCommand>().ExecuteAsync(imageId);
            return RedirectToAction(nameof(Upsert), new { id = imageToBeDeleted.CityId });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var city = await _factory.Create<GetCityByIdQuery>().ExecuteAsync(id, string.Empty);
            if (city == null)
                return NotFound();

            string cityPath = $"images/cities/city-{id}";
            string finalPath = Path.Combine(_webHostEnvironment.WebRootPath, cityPath);

            if (Directory.Exists(finalPath))
            {
                Directory.Delete(finalPath, true);
            }

            await _factory.Create<DeleteCityCommand>().ExecuteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
