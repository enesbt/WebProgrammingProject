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

        public HomeController(IHtmlLocalizer<Controllers.HomeController> htmlLocalizer)
            => _htmlLocalizer = htmlLocalizer;


        public IActionResult Index()
        {

            ViewBag.PageHome = _htmlLocalizer["page.Home"];
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}