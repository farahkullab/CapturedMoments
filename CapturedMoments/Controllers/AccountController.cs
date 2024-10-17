using CapturedMoments.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CapturedMoments.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> _signInManager,RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            signInManager = _signInManager;
            _roleManager = roleManager;
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
                    if (User.IsInRole("Photographer"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "PhotographerDashboard" });
                    }
                    else if (User.IsInRole("Admin"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Dashboard" });
                    }
                    
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

        #region Roles 
        [HttpGet]
        public async Task<IActionResult> RolesList()
        {
            return View(await _roleManager.Roles.ToListAsync());
        }

        [HttpGet]
        public IActionResult CreateRole()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = model.RoleName
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(RolesList));
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
                return View(model);
            }
            return View(model);
        }




        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            if (id == null) { return NotFound(); }
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) { return NotFound(); }
            EditRoleViewModel model = new EditRoleViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var x = await _roleManager.FindByIdAsync(model.RoleId);
                if (x == null) { return NotFound(); }
                x.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(x);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(RolesList));
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
                return View(model);
            }
            return View(model);

        }




        public async Task<IActionResult> DeleteRole(string id)
        {
            if (id == null) { return NotFound(); }
            var role = await _roleManager.FindByIdAsync((string)id);
            if (role == null) { return NotFound(); }
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(RolesList));
            }
            return RedirectToAction(nameof(RolesList));
        }
        #endregion

    }
}
