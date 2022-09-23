using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Register()
        {
            IdentityUser user = new IdentityUser
            {
                UserName = "amirad",
            };

            var result = await _userManager.CreateAsync(user, "123qwe!@#QWE");

            if (result.Succeeded)
            {
                return Content("user created successfully");
            }

            return Content("Failed to create user");
        }

        public async Task<IActionResult> CreateRoleAndUsers()
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Administrators";
            await _roleManager.CreateAsync(role);

            IdentityUser user1 = new IdentityUser
            {
                UserName = "amirad",
            };

            await _userManager.CreateAsync(user1, "123qwe!@#QWE");

            await _userManager.AddToRoleAsync(user1, "Administrators");

            IdentityUser user2 = new IdentityUser
            {
                UserName = "moshel",
            };

            await _userManager.CreateAsync(user2, "123qwe!@#QWE");

            return Content("Role and users were created");
        }
    }
}
