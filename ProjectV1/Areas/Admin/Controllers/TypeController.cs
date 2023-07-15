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
    public class TypeController : Controller
    {
        private readonly IAnimalTypeService _animalTypeService;

        public TypeController(IAnimalTypeService animalTypeService)
        {
            _animalTypeService = animalTypeService;
        }

        public IActionResult Index()
        {
            var values = _animalTypeService.GetList();

            return View(values) ;
        }
        [HttpGet]
        public IActionResult AddType()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddType(AnimalType p)
        {
            p.Status = true;
            _animalTypeService.TAdd(p);
            return RedirectToAction("Index", "Type");
        }


    }
}
