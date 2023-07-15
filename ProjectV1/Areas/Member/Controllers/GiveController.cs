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
    public class GiveController : Controller
    {
        private readonly IAnimalGiveService _animalGiveService;
        private readonly UserManager<AppUser> _userManager;

        public GiveController(IAnimalGiveService animalGiveService, UserManager<AppUser> userManager)
        {
            _animalGiveService = animalGiveService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _animalGiveService.GetAnimalGiveById(user.Id);
            return View(values);
        }
    }
}
