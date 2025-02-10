using AncientCities.Application.AncientCityType;
using AncientCities.Application.AncientCityType.Commands;
using AncientCities.Application.AncientCityType.Queries;
using AncientCities.Application.CommonData.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AncientCities.WebAPI.Controllers
{
    [Controller]
    public class CityTypeController : Controller
    {
        private readonly IQueryCommandFactory _factory;

        public CityTypeController(IQueryCommandFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cityTypes = await _factory.Create<GetAllCityTypesQuery>().ExecuteAsync();
            return View(cityTypes);
        }

        [HttpGet]
        public async Task<IActionResult> Upsert(int? id)
        {
            if (id == null || id == 0)
                return View(new CityTypeDto());

            var cityType = await _factory.Create<GetCityTypeByIdQuery>().ExecuteAsync(id.Value);
            if (cityType == null)
                return NotFound();

            return View(cityType);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(CityTypeDto cityTypeDto)
        {
            if (ModelState.IsValid)
            {
                await _factory.Create<UpsertCityTypeCommand>().ExecuteAsync(cityTypeDto);
                return RedirectToAction("Index");
            }
            return View(cityTypeDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _factory.Create<DeleteCityTypeCommand>().ExecuteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
