using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Project.Models;

namespace Project.Controllers
{
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
     
            
        public RegisterController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}

        [HttpPost]
        public async  Task<IActionResult> SignUp(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Age = registerViewModel.Age,
                    Adress = registerViewModel.Adress,
                    UserName = registerViewModel.Email,
                };

                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                

                
                

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Member");
                    return RedirectToAction("Index", "Login");
                }
                else
                    result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));

            }
            return View();
        }
    }
}
