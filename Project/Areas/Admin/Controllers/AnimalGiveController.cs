using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Project.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    [Authorize(Roles = "Admin")]
    public class AnimalGiveController : Controller
    {
        private readonly IAnimalGiveService _animalGiveService;

        public AnimalGiveController(IAnimalGiveService animalGiveService)
        {
            _animalGiveService = animalGiveService;
        }

        public IActionResult Index()
        {
            var values = _animalGiveService.GetListJoinTable();
            return View(values);
        }

        [HttpGet]
        public IActionResult Active(int id)
        {
            var post = _animalGiveService.GetById(id);
            post.Status = true;
            _animalGiveService.TUpdate(post);
            return RedirectToAction("Index", "AnimalGive");
        }
        [HttpGet]
        public IActionResult Passive(int id)
        {
            var post = _animalGiveService.GetById(id);
            post.Status = false;
            _animalGiveService.TUpdate(post);
            return RedirectToAction("Index", "AnimalGive");
        }
    }
}
