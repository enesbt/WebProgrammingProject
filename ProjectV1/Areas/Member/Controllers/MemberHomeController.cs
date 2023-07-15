

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Project.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[Controller]/[Action]")]
    [Authorize(Roles ="Member")]
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
