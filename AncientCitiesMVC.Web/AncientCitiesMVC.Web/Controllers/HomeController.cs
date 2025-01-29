using AncientCitiesMVC.Data.DbApplicationContext;
using AncientCitiesMVC.Data.Repository.Interfaces;
using AncientCitiesMVC.Models;
using AncientCitiesMVC.Utility.CommonData;
using AncientCitiesMVC.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EnumHelper = AncientCitiesMVC.Utility.Helpers.EnumHelper;

namespace AncientCitiesMVC.Web.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ApplicationDbContext context, IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<City> list = _unitOfWork.CityRepository.GetAll(includeProperties: "Type").ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> typeList = _unitOfWork.CityTypeRepository.GetAll().ToList().Select(x =>
               new SelectListItem { Value = x.Id.ToString(), Text = x.Name });

            CityViewModel cityViewModel = new CityViewModel()
            {
                CityTypes = typeList,
                City = new City(),
                EraNames = EnumHelper.GetEnumSelectList<Era.EraNames>()
            };

            ViewBag.EraNames = EnumHelper.GetEnumSelectList<Era.EraNames>();

            if (id == null || id == 0)
            {
                return View(cityViewModel);
            }
            else
            {
                cityViewModel.City = _unitOfWork.CityRepository.Get(x => x.Id == id, includeProperties: "CityImages");
                if (cityViewModel.City == null)
                    return NotFound();

                cityViewModel.EraCreatedInt = cityViewModel.City.EraCreated == "BC" ? 0 : 1;
                cityViewModel.EraDefunctInt = cityViewModel.City.EraDefunct == "BC" ? 0 : 1;

                ViewBag.EraNames = EnumHelper.GetEnumSelectList<Era.EraNames>();

                return View(cityViewModel);
            }
        }

        [HttpPost]
        public IActionResult Upsert(CityViewModel cityViewModel, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                cityViewModel.City.EraCreated = cityViewModel.EraCreatedInt == 0 ? "BC" : cityViewModel.City.EraCreated = cityViewModel.EraCreatedInt == 1 ? "AD" : null;
                cityViewModel.City.EraDefunct = cityViewModel.EraDefunctInt == 0 ? "BC" : cityViewModel.City.EraDefunct = cityViewModel.EraDefunctInt == 1 ? "AD" : null;

                if (cityViewModel.City.Id == 0)
                {
                    _unitOfWork.CityRepository.Add(cityViewModel.City);
                }
                else
                {
                    _unitOfWork.CityRepository.Update(cityViewModel.City);
                }

                _unitOfWork.Save();

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

                    _unitOfWork.CityRepository.Update(cityViewModel.City);
                    _unitOfWork.Save();
                }

                return RedirectToAction("Index");
            }

            cityViewModel.EraNames = EnumHelper.GetEnumSelectList<Era.EraNames>();
            return View(cityViewModel);
        }

        public IActionResult DeleteImage(int imageId)
        {
            var imageToBeDeleted = _unitOfWork.CityImageRepository.Get(x => x.Id == imageId);
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

                _unitOfWork.CityImageRepository.Remove(imageToBeDeleted);
                _unitOfWork.Save();
            }

            return RedirectToAction(nameof(Upsert), new { id = cityId });
        }

        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.CityRepository.Get(x => x.Id == id);
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

            _unitOfWork.CityRepository.Remove(obj);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
