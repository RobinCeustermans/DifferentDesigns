using AncientCities.Application.DTOs;
using AncientCities.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AncientCities.WebAPI.Controllers
{
    [Controller]
    public class CityTypeController : Controller
    {
        private readonly ICityTypeService _cityTypeService;

        public CityTypeController(ICityTypeService cityTypeService)
        {
            _cityTypeService = cityTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cityTypes = await _cityTypeService.GetAllCityTypesAsync();
            return View(cityTypes);
        }

        [HttpGet]
        public async Task<IActionResult> Upsert(int? id)
        {
            if (id == null || id == 0)
                return View(new CityTypeDto());

            var cityType = await _cityTypeService.GetCityTypeByIdAsync(id.Value);
            if (cityType == null)
                return NotFound();

            return View(cityType);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(CityTypeDto cityTypeDto)
        {
            if (ModelState.IsValid)
            {
                await _cityTypeService.UpsertCityTypeAsync(cityTypeDto);
                return RedirectToAction("Index");
            }
            return View(cityTypeDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _cityTypeService.DeleteCityTypeAsync(id);
            return RedirectToAction("Index");
        }
    }
}
