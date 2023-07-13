using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Project.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    [Authorize(Roles = "Admin")]
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        public IActionResult Index()
        {
            var values = _animalService.GetList();
            return View(values);
        }


        [HttpGet]
        public IActionResult Active(int id)
        {
            var post = _animalService.GetById(id);
            post.Status = true;
            _animalService.TUpdate(post);
            return RedirectToAction("Index", "Animal");
        }
        [HttpGet]
        public IActionResult Passive(int id)
        {
            var post = _animalService.GetById(id);
            post.Status = false;
            _animalService.TUpdate(post);
            return RedirectToAction("Index", "Animal");
        }

    }
}
