using DataAccess.Models.IdentityModules;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectPresentation.ViewModels;

namespace ProjectPresentation.Controllers
{
    public class AccountController(UserManager<AppUser> _userManager,SignInManager<AppUser> _signInManager) : Controller
    {
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);
            var registerUser = new AppUser()
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.SecondName,
                Email = registerViewModel.Email,
                UserName = registerViewModel.UserName
            };

            var result = _userManager.CreateAsync(registerUser, registerViewModel.Password).Result;

            if (result.Succeeded) return RedirectToAction("Login", "Account");
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerViewModel);
            }

        }
        #endregion


        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);
            var user = _userManager.FindByEmailAsync(loginViewModel.Email).Result;
            if (user is not null)
            {
                bool result = _userManager.CheckPasswordAsync(user, loginViewModel.Password).Result;
                if (!result) return View(loginViewModel);
                var result1 = _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false).Result;
                if(result1.IsNotAllowed) ModelState.AddModelError("", "Email Not Confirmed");
                if(result1.IsLockedOut) ModelState.AddModelError("", "Your Account is Locked");
                if(result1.Succeeded) return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Lgoin");

                
            }
            return View(loginViewModel);
        }
        #endregion
    }
}
