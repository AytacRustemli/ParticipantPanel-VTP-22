using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ParticipantPanel.ViewModels;

namespace ParticipantPanel.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM, string RetypePassword)
        {
            if (ModelState.IsValid)
            {
                if (registerVM.Password != RetypePassword)
                {
                    ViewBag.Password = "Şifrələr üst-üstə düşmür.";
                    return View();
                }

                User user = new()
                {
                    UserName = registerVM.Name,
                    Email = registerVM.Email,
                    Name = registerVM.Name,
                    Surname = registerVM.Surname
                };

                IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            return View();

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user == null) return View();
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
            if (!result.Succeeded)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
