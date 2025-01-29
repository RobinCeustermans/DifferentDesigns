using AncientCitiesMVC.Data.Repository.Interfaces;
using AncientCitiesMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AncientCitiesMVC.Web.Controllers
{
    [Controller]
    public class CityTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CityTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<CityType> cityTypes = _unitOfWork.CityTypeRepository.GetAll().ToList();
            return View(cityTypes);
        }

        [HttpGet]
        public IActionResult GetCityTypes()
        {
            var cityTypes = _unitOfWork.CityTypeRepository.GetAll().ToList();
            return Ok(cityTypes);
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                return View(new CityType());
            }
            else
            {
                var cityType = _unitOfWork.CityTypeRepository.Get(x => x.Id == id);
                if (cityType == null)
                    return NotFound();

                return View(cityType);
            }
        }

        [HttpPost]
        public IActionResult Upsert(CityType cityType)
        {
            if (ModelState.IsValid)
            {
                if (cityType.Id == 0)
                {
                    _unitOfWork.CityTypeRepository.Add(cityType);
                }
                else
                {
                    _unitOfWork.CityTypeRepository.Update(cityType);
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Upsert");
            }
        }

        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.CityTypeRepository.Get(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.CityTypeRepository.Remove(obj);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
