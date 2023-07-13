using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Project.Areas.Member.Controllers
{

    [Area("Member")]
    [Route("Member/[Controller]/[Action]")]
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
    }
}
