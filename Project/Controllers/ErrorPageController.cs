using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Index404()
        {
            return View();
        }
    }
}
