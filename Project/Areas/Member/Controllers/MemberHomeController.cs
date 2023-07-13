

using Microsoft.AspNetCore.Mvc;

namespace Project.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[Controller]/[Action]")]
    public class MemberHomeController : Controller
	{
		public IActionResult Index()
		{
            var name = User.Identity.Name;
            ViewBag.value = name;
            return View();
		}
	}
}
