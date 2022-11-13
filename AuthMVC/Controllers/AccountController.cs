using Microsoft.AspNetCore.Mvc;

namespace AuthMVC.Controllers
{
	public class AccountController:Controller
	{
		//GET /<controller>/
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
	}
}
