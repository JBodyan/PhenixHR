using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        [TempData]
        public string StatusMessage { get; set; }

        public AccountController(SignInManager<AppUser> signInManager, ILogger<LoginModel> logger, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> LoginOnPostAsync(LoginModel model,string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    _logger.LogInformation($"User ({model.Email}) logged in.");
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
                    _logger.LogInformation($"Ivalid login attempt ({model.Email})");
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View("Login");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [Authorize(Roles = "SUAdministrator")]
        public IActionResult RegisterAdministrator()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "SUAdministrator")]
        public async Task<IActionResult> RegisterAdministrator(RegisterAdministratorModel model)
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "SUAdministrator, Administrator")]
        public IActionResult RegisterHRManager()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "SUAdministrator, Administrator")]
        public async Task<IActionResult> RegisterHRManager(RegisterAdministratorModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "HRManager");
                    _logger.LogInformation($"Manager created ({user.Email})");

                    return RedirectToAction("AllManagers");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "SUAdministrator, Administrator")]
        public async Task<IActionResult> AllManagers()
        {
            var managers = await _userManager.GetUsersInRoleAsync("HRManager");
            if (managers.Count > 0) return View(managers);

            ModelState.AddModelError(string.Empty, "Not found managers.");
            return View();
        }

    }
}