using AncientCitiesVSA.Features.CityType.DeleteCityType;
using AncientCitiesVSA.Features.CityType.DomainModels;
using AncientCitiesVSA.Features.CityType.DTOs;
using AncientCitiesVSA.Features.CityType.GetCityTypeById;
using AncientCitiesVSA.Features.CityType.GetCityTypes;
using AncientCitiesVSA.Features.CityType.UpsertCityType;
using Microsoft.AspNetCore.Mvc;

namespace AncientCitiesVSA.Features.CityType.Controllers
{
    public class CityTypeController : Controller
    {
        private readonly IGetCityTypesHandler _getCityTypesHandler;
        private readonly IGetCityTypeByIdHandler _getCityTypeByIdHandler;
        private readonly IUpsertCityTypeHandler _upsertCityTypeHandler;
        private readonly IDeleteCityTypeHandler _deleteCityTypeHandler;

        public CityTypeController(
            IGetCityTypesHandler getCityTypesHandler,
            IGetCityTypeByIdHandler getCityTypeByIdHandler,
            IUpsertCityTypeHandler upsertCityTypeHandler,
            IDeleteCityTypeHandler deleteCityTypeHandler)
        {
            _getCityTypesHandler = getCityTypesHandler;
            _getCityTypeByIdHandler = getCityTypeByIdHandler;
            _upsertCityTypeHandler = upsertCityTypeHandler;
            _deleteCityTypeHandler = deleteCityTypeHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cityTypes = await _getCityTypesHandler.ExecuteAsync();
            return View("Features/CityType/Views/CityType/Index.cshtml", cityTypes);
        }

        [HttpGet]
        public async Task<IActionResult> Upsert(int? id)
        {
            if (id == null || id == 0)
                return View("Features/CityType/Views/CityType/Upsert.cshtml", new CityTypeDTO());

            var cityType = await _getCityTypeByIdHandler.ExecuteAsync(id.Value);
            if (cityType == null)
                return NotFound();

            return View("Features/CityType/Views/CityType/Upsert.cshtml", cityType);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(CityTypeDTO cityTypeDto)
        {
            if (ModelState.IsValid)
            {
                await _upsertCityTypeHandler.ExecuteAsync(cityTypeDto);
                return RedirectToAction(nameof(Index));
            }
            return View("Features/CityType/Views/CityType/Upsert.cshtml", cityTypeDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _deleteCityTypeHandler.ExecuteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
