using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Project.Areas.Member.Controllers
{

    [Area("Member")]
    [Route("Member/[Controller]/[Action]")]
    [Authorize(Roles = "Member")]
    public class BarinakController : Controller
    {
        private readonly IAnimalRequestService _animalRequestService;

        public BarinakController(IAnimalRequestService animalRequestService)
        {
            _animalRequestService = animalRequestService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _animalRequestService.GetListJoinTable();
           
            return View(values);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var value = _animalRequestService.GetAnimalRequestById(id);
            return View(value);
        }
    }
}
