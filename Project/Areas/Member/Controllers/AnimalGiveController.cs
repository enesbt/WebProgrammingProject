using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Project.Areas.Member.Controllers
{

    [Area("Member")]
    [Route("Member/[Controller]/[Action]")]
    public class AnimalGiveController : Controller
    {
        private readonly IAnimalGiveService _animalGiveService;

        private readonly UserManager<AppUser> _userManager;

        public AnimalGiveController(IAnimalGiveService animalGiveService, UserManager<AppUser> userManager)
        {
            _animalGiveService = animalGiveService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var value =  _animalGiveService.GetById(id);
            ViewBag.Id = id;
            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            AnimalGive animalGive = new AnimalGive();
            animalGive.Status = false;
            animalGive.time = DateTime.UtcNow;
            animalGive.AnimalId = ViewBag.Id ;
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            animalGive.Id = user.Id;
            _animalGiveService.TAdd(animalGive);
            return RedirectToAction("Index", "AnimalGive");
        }

    }
}
