using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebPhenix.Data;
using WebPhenix.Models.Identity;

namespace WebPhenix.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        [TempData]
        public string StatusMessage { get; set; }

        public AccountController(SignInManager<AppUser> signInManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IActionResult> LoginOnPostAsync(LoginModel model,string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View("Login");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction("Login", "Account");
        }

        [Authorize(Roles = "SUAdmin")]
        public IActionResult RegisterAdministrator()
        {
            return View();
        }

        [Authorize(Roles = "SUAdmin")]
        public async Task<IActionResult> RegisterAdministrator(RegisterAdministratorModel model)
        {
            return View();
        }

        [Authorize(Roles = "SUAdmin")]
        [Authorize(Roles = "Administrator")]
        public IActionResult RegisterHRManager()
        {
            return View();
        }

        [Authorize(Roles = "SUAdmin")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> RegisterHRManager(RegisterAdministratorModel model)
        {

            return View();
        }

    }
}