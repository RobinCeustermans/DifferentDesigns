using AncientCities.Application.CommonData;
using AncientCities.Application.DTOs;
using AncientCities.Application.Interfaces;
using AncientCities.Application.Interfaces.Services;
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
        private readonly ICityService _cityService;
        private readonly ICityTypeService _cityTypeService;
        private readonly ICityImageService _cityImageService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CityController(ICityService cityService, ICityTypeService cityTypeService, IWebHostEnvironment webHostEnvironment, ICityImageService cityImageService)
        {
            _cityService = cityService;
            _cityTypeService = cityTypeService;
            _webHostEnvironment = webHostEnvironment;
            _cityImageService = cityImageService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CityDto> list = await _cityService.GetAllCitiesAsync();
            return View(list);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            IEnumerable<SelectListItem> typeList = (await _cityTypeService.GetAllCityTypesAsync())
            .Select(cityType => new SelectListItem
            {
                 Value = cityType.Id.ToString(),
                 Text = cityType.Name
            });

            CityViewModel cityViewModel = new CityViewModel
            {
                CityTypes = typeList,
                City = new CityDto(),
                EraNames = EnumHelper.GetEnumSelectList<Era.EraNames>()
            };

            ViewBag.EraNames = EnumHelper.GetEnumSelectList<Era.EraNames>();

            if (id == null || id == 0)
            {
                return View(cityViewModel);
            }
            else
            {
                cityViewModel.City = await _cityService.GetCityByIdAsync(id.Value, includeProperties: "CityImages");
                if (cityViewModel.City == null)
                    return NotFound();

                cityViewModel.EraCreatedInt = cityViewModel.City.EraCreated == "BC" ? 0 : 1;
                cityViewModel.EraDefunctInt = cityViewModel.City.EraDefunct == "BC" ? 0 : 1;

                ViewBag.EraNames = EnumHelper.GetEnumSelectList<Era.EraNames>();

                return View(cityViewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(CityViewModel cityViewModel, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                cityViewModel.City.EraCreated = cityViewModel.EraCreatedInt == 0 ? "BC" : cityViewModel.City.EraCreated = cityViewModel.EraCreatedInt == 1 ? "AD" : null;
                cityViewModel.City.EraDefunct = cityViewModel.EraDefunctInt == 0 ? "BC" : cityViewModel.City.EraDefunct = cityViewModel.EraDefunctInt == 1 ? "AD" : null;

                string wwwrootPath = _webHostEnvironment.WebRootPath;

                if (files != null)
                {
                    foreach (IFormFile file in files)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string productParh = @"images\cities/city-" + cityViewModel.City.Id;
                        string finalPath = Path.Combine(wwwrootPath, productParh);

                        if (!Directory.Exists(finalPath))
                        {
                            Directory.CreateDirectory(finalPath);
                        }

                        using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        CityImage image = new CityImage()
                        {
                            CityId = cityViewModel.City.Id,
                            ImageUrl = @"\" + productParh + @"\" + fileName
                        };                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     


                        if (cityViewModel.City.CityImages == null)
                        {
                            cityViewModel.City.CityImages = new List<CityImage>();
                        }

                        cityViewModel.City.CityImages.Add(image);
                    }
                }
                
                await _cityService.UpsertCityAsync(cityViewModel.City);
                return RedirectToAction("Index");
            }

            cityViewModel.EraNames = EnumHelper.GetEnumSelectList<Era.EraNames>();
            return View(cityViewModel);
        }

        public async Task< ActionResult> DeleteImage(int imageId)
        {
            var imageToBeDeleted = await _cityImageService.GetCityImageByIdAsync(imageId);
            int cityId = imageToBeDeleted.CityId;
            if (imageToBeDeleted != null)
            {
                if (!string.IsNullOrEmpty(imageToBeDeleted.ImageUrl))
                {
                    var oldPath = Path.Combine(_webHostEnvironment.WebRootPath, imageToBeDeleted.ImageUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }

                await _cityImageService.DeleteCityImageAsync(imageId);
            }

            return RedirectToAction(nameof(Upsert), new { id = cityId });
        }


        public async Task<IActionResult> Delete(int id)
        {
            var obj = await _cityService.GetCityByIdAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            string cityPath = @"images\cities/city-" + id;
            string finalPath = Path.Combine(_webHostEnvironment.WebRootPath, cityPath);

            if (Directory.Exists(finalPath))
            {
                string[] filePaths = Directory.GetFiles(finalPath);
                foreach (string filePath in filePaths)
                {
                    System.IO.File.Delete(filePath);
                }

                Directory.Delete(finalPath);
            }

            await _cityService.DeleteCityAsync(id);

            return RedirectToAction("Index");
        }

    }
}
