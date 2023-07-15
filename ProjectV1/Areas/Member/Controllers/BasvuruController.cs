using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Project.Areas.Member.Controllers
{

    [Area("Member")]
    [Route("Member/[Controller]/[Action]")]
    [Authorize(Roles = "Member")]
    public class BasvuruController : Controller
    {
        private readonly IAnimalGiveService _animalGiveService;
        private readonly IAnimalRequestService _animalRequestService;
        private readonly UserManager<AppUser> _userManager;

        public BasvuruController(IAnimalGiveService animalGiveService, IAnimalRequestService animalRequestService, UserManager<AppUser> userManager)
        {
            _animalGiveService = animalGiveService;
            _animalRequestService = animalRequestService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var value = _animalRequestService.GetAnimalRequestById(id);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            
            AnimalGive animalGive = new AnimalGive();
            animalGive.Id = user.Id;
            animalGive.AnimalId = value.AnimalId;
            animalGive.Status = false;
            animalGive.time = DateTime.UtcNow;
            _animalGiveService.TAdd(animalGive);

            return RedirectToAction("Index","MemberHome");
        }
    }
}
