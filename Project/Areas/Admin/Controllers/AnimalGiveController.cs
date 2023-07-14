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
    public class AnimalGiveController : Controller
    {
        private readonly IAnimalGiveService _animalGiveService;
        private readonly IAnimalService _animalService;

        public AnimalGiveController(IAnimalGiveService animalGiveService, IAnimalService animalService)
        {
            _animalGiveService = animalGiveService;
            _animalService = animalService;
        }

        public IActionResult Index()
        {
            var values = _animalGiveService.GetListJoinTable();
            return View(values);
        }

        [HttpGet]
        public IActionResult Active(int id)
        {
            var post = _animalGiveService.GetByIdWithAnimal(id);
            post.Status = true;
            int animalid = post.Animal.AnimalId;
            var animal =_animalService.GetById(animalid);
            animal.Status = false;

            _animalService.TUpdate(animal);
            _animalGiveService.TUpdate(post);
            return RedirectToAction("Index", "AnimalGive");
        }
        [HttpGet]
        public IActionResult Passive(int id)
        {
            var post = _animalGiveService.GetByIdWithAnimal(id);
            post.Status = false;
            post.Animal.Status = true;

            int animalid = post.Animal.AnimalId;
            var animal = _animalService.GetById(animalid);
            animal.Status = false;

            _animalService.TUpdate(animal);
            _animalGiveService.TUpdate(post);
            return RedirectToAction("Index", "AnimalGive");
        }
    }
}
