using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthMVC.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<IdentityUser> _userManager;





        public RoleController(RoleManager<IdentityRole>roleManager, UserManager<IdentityUser>userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        //retourner tous les rôles
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        //retourner tous les utilisateurs
        public IActionResult ListUsers()
        {
            var users = _userManager.Users;
            return View(users);
        }





        //create role
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View(new IdentityRole());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(IdentityRole role)
        {
            await _roleManager.CreateAsync(role);
            return View();
        }



        //create user
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View(new IdentityUser());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(IdentityUser user)
        {
            await _userManager.CreateAsync(user);
            return View();
        }



        //[HttpGet]
        //public async Task<IActionResult> EditUser(string id)
        //{
        //    var user = await _userManager.FindByIdAsync(id);

        //    if(_userManager==null)
        //    {
        //        ViewBag.ErrorMessage = $"User with Id ={id} cannot be found";
        //        return View("Not Found");
        //    }

        //}








        public async Task<IActionResult> GetMyRoles()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(userEmail);
            var roles = await _userManager.GetRolesAsync(user);
            return View(roles);
        }


       


    }
}
