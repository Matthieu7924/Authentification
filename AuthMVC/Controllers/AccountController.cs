using AuthMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthMVC.Controllers
{
	public class AccountController:Controller
	{
		//propriétés
		private readonly UserManager<IdentityUser> userManager;
		private readonly SignInManager<IdentityUser> signInManager;	


		//constructeur
		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser>signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}






		//GET /<controller>/
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
			if(ModelState.IsValid)
			{
				var user = new IdentityUser { UserName = model.Email, Email = model.Email };
				var result = await userManager.CreateAsync(user, model.Password);

				if(result.Succeeded)
				{
					await signInManager.SignInAsync(user, isPersistent: false);//false pour session cookie // true pour permanent cookie
					return RedirectToAction("index", "home");
				}

				foreach(var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}
            return View(model);
        }



    }
}
