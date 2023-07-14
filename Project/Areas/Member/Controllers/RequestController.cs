using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace Project.Areas.Member.Controllers
{

    [Area("Member")]
    [Route("Member/[Controller]/[Action]")]
    [Authorize(Roles = "Member")]
    public class RequestController : Controller
    {
        private readonly IAnimalRequestService _animalRequestService;
        private readonly IAnimalService _animalService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAnimalTypeService _animalTypeService;
        private readonly IAnimalHouseService _animalHouseService;

        public RequestController(IAnimalRequestService animalRequestService, IAnimalService animalService, UserManager<AppUser> userManager, IAnimalTypeService animalTypeService, IAnimalHouseService animalHouseService)
        {
            _animalRequestService = animalRequestService;
            _animalService = animalService;
            _userManager = userManager;
            _animalTypeService = animalTypeService;
            _animalHouseService = animalHouseService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddAnimal()
        {
            List<SelectListItem> type = (from item in _animalTypeService.GetList()
                                         select new SelectListItem
                                         {
                                             Text = item.Name,
                                             Value = item.AnimalTypeId.ToString()
                                         }).ToList();
            List<SelectListItem> house = (from item in _animalHouseService.GetList()
                                         select new SelectListItem
                                         {
                                             Text = item.Name,
                                             Value = item.AnimalHouseId.ToString()
                                         }).ToList();
            ViewBag.house = house;  
            ViewBag.type = type;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAnimal(Animal animal)
        {

            _animalService.TAdd(animal);
            animal.Status = true;
            AnimalRequest animalRequest = new AnimalRequest();
            animalRequest.Status = false;
            animalRequest.AnimalId= animal.AnimalId;
            animalRequest.time = DateTime.UtcNow;
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            animalRequest.Id = user.Id;
            _animalRequestService.TAdd(animalRequest);
            return RedirectToAction("Index", "Request");
        }
        [HttpGet]
        public async Task<IActionResult> MyRequest()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _animalRequestService.GetAnimalRequestById(user.Id);
           
            return View(values);
        }

    }
}
