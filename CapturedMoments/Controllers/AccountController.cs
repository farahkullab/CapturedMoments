using CapturedMoments.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CapturedMoments.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> _signInManager)
        {
            this.userManager = userManager;
            signInManager = _signInManager;
        }

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            ApplicationUser user = new ApplicationUser
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                UserName = model.Email,
            };

            var r = await userManager.CreateAsync(user, model.Password);
            if (r.Succeeded)

            {
                return RedirectToAction("Login");
            }
            foreach (var err in r.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }
            return View(model);
        }
        #endregion

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new { area = "Dashboard" });
                }
                ModelState.AddModelError("", "Invalid User or password");
                return View(model);

            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
