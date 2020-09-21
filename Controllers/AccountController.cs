using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            // czy wprowadzone dane są poprawne
            if (!ModelState.IsValid)
                // jeżeli nie to zwróc widok (pokaż okno logowania)
                return View(user);
            // jeżeli dane są poprawne to wyszukaj użytkownika
            var users = await _userManager.FindByNameAsync(user.UserName);

            if (users != null)
            {
                var result = await _signInManager.PasswordSignInAsync(users, user.Password, false, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Book");
            }
            ModelState.AddModelError("", "Nazwa użytkownika / hasło jest niewłaściwe");
            return View(user);
        }

        public IActionResult Register()
        {
            return View(new User());
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                var users = new IdentityUser() { UserName = user.UserName };
                var result = await _userManager.CreateAsync(users, user.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
