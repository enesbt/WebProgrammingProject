using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using Project.Models;
using System.Diagnostics;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHtmlLocalizer<Controllers.HomeController> _htmlLocalizer;

        private readonly IAnimalRequestService _animalRequestService;

        public HomeController(IHtmlLocalizer<HomeController> htmlLocalizer, IAnimalRequestService animalRequestService)
        {
            _htmlLocalizer = htmlLocalizer;
            _animalRequestService = animalRequestService;
        }

        public IActionResult Index()
        {
            var values = _animalRequestService.GetListJoinTable();

            return View(values);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}