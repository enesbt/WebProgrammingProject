using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Project.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    [Authorize(Roles = "Admin")]
    public class AnimalRequestController : Controller
    {
        private readonly IAnimalRequestService _animalRequestService;

        public AnimalRequestController(IAnimalRequestService animalRequestService
            )
        {
            _animalRequestService = animalRequestService;
        }

        public IActionResult Index()
        {
            var values = _animalRequestService.GetListJoinTable();
            return View(values);
        }

        [HttpGet]
        public IActionResult Active(int id)
        {
            var post = _animalRequestService.GetById(id);
            post.Status = true;
            _animalRequestService.TUpdate(post);
            return RedirectToAction("Index", "AnimalRequest");
        }
        [HttpGet]
        public IActionResult Passive(int id)
        {
            var post = _animalRequestService.GetById(id);
            post.Status = false;
            _animalRequestService.TUpdate(post);
            return RedirectToAction("Index", "AnimalRequest");
        }
    }
}
