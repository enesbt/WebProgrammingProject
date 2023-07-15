using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Project.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    [Authorize(Roles = "Admin")]
    public class AnimalHomeController : Controller
    {
        private readonly IAnimalHouseService _animalHouseService;

        public AnimalHomeController(IAnimalHouseService animalHouseService
            
            )
        {
            _animalHouseService = animalHouseService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var values = _animalHouseService.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddHouse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddHouse(AnimalHouse house)
        {
            house.Status = true;
            _animalHouseService.TAdd(house);
            return RedirectToAction("Index", "AnimalHome");
        }
    }
}
