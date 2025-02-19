using AncientCities.Application.DTOs;
using AncientCities.Application.Interfaces;
using AncientCities.Application.UseCases.City.Commands;
using AncientCities.Application.UseCases.City.Queries;
using AncientCities.Application.UseCases.CityImage.Commands;
using AncientCities.Application.UseCases.CityImage.Queries;
using AncientCities.Application.UseCases.CityType.Queries;
using AncientCities.Domain.Aggregates.CityAggregate.ValueObjects;
using AncientCities.Domain.Aggregates.CityAggregate;
using AncientCitiesDDD.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AncientCities.WebAPI.Views.Helpers;

namespace AncientCitiesDDD.Controllers
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

            if (files != null && files.Any())
            {
                await SaveCityImagesAsync(cityViewModel.City.Id, files, cityViewModel.City);
            }

            await _factory.Create<UpsertCityCommand>().ExecuteAsync(cityViewModel.City);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteImage(int imageId)
        {
            var imageToBeDeleted = await _factory.Create<GetCityImageByIdQuery>().ExecuteAsync(imageId);
            if (imageToBeDeleted == null)
                return NotFound();

            DeleteImageFromServer(imageToBeDeleted);
            await _factory.Create<DeleteCityImageCommand>().ExecuteAsync(imageId);
            return RedirectToAction(nameof(Upsert), new { id = imageToBeDeleted.CityId });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var city = await _factory.Create<GetCityByIdQuery>().ExecuteAsync(id, string.Empty);
            if (city == null)
                return NotFound();

            DeleteCityFolder(id);
            await _factory.Create<DeleteCityCommand>().ExecuteAsync(id);
            return RedirectToAction("Index");
        }

        private async Task SaveCityImagesAsync(int cityId, List<IFormFile> files, CityDto city)
        {
            string wwwrootPath = _webHostEnvironment.WebRootPath;
            string cityPath = $"images/cities/city-{cityId}";
            string finalPath = Path.Combine(wwwrootPath, cityPath);

            if (!Directory.Exists(finalPath))
            {
                Directory.CreateDirectory(finalPath);
            }

            foreach (IFormFile file in files)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(finalPath, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                city.CityImages ??= new List<CityImage>();
                city.CityImages.Add(new CityImage
                {
                    CityId = cityId,
                    ImageUrl = $"/{cityPath}/{fileName}"
                });
            }
        }

        private void DeleteImageFromServer(CityImageDto image)
        {
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, image.ImageUrl.TrimStart('/'));
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        private void DeleteCityFolder(int cityId)
        {
            string cityPath = Path.Combine(_webHostEnvironment.WebRootPath, $"images/cities/city-{cityId}");
            if (Directory.Exists(cityPath))
            {
                Directory.Delete(cityPath, true);
            }
        }
    }
}
