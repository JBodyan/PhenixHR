using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhenixProject.Data;
using PhenixProject.Models;
using PhenixProject.Models.Identity;
using X.PagedList;

namespace PhenixProject.Controllers
{
    public class AccountController : Controller
    {
        private const int PageSize = 3;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IHostingEnvironment _webHost;

        [TempData]
        public string StatusMessage { get; set; }

        public AccountController(SignInManager<AppUser> signInManager, ILogger<LoginModel> logger, UserManager<AppUser> userManager, IHostingEnvironment webHost)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _webHost = webHost;
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
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Photo = @"/Photo/empty.png"
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Administrator");
                    _logger.LogInformation($"Administrator created ({user.Email})");

                    return RedirectToAction("AllAdministrators");
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
                    LastName = model.LastName,
                    Photo = @"/Photo/empty.png"
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
        public async Task<IActionResult> AllManagers(string searchString, int? page)
        {
            var managers = await _userManager.GetUsersInRoleAsync("HRManager");
            if (managers.Count > 0)
            {
                if (!string.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.ToUpper();
                    managers = managers.Where(
                        x => x.FirstName.ToUpper().Contains(searchString)
                             || x.LastName.ToUpper().Contains(searchString)
                    ).ToList();
                }
                var pageNumber = (page ?? 1);
                return View(await managers.ToPagedListAsync(pageNumber, PageSize));
            }

            ModelState.AddModelError(string.Empty, "Not found managers.");
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "SUAdministrator")]
        public async Task<IActionResult> AllAdministrators(string searchString, int? page)
        {
            var admins = await _userManager.GetUsersInRoleAsync("Administrator");
            if (admins.Count > 0)
            {
                if (!string.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.ToUpper();
                    admins = admins.Where(
                        x => x.FirstName.ToUpper().Contains(searchString)
                             || x.LastName.ToUpper().Contains(searchString)
                    ).ToList();
                }
                var pageNumber = (page ?? 1);
                return View(await admins.ToPagedListAsync(pageNumber, PageSize));
            }

            ModelState.AddModelError(string.Empty, "Not found administrators.");
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "SUAdministrator, Administrator")]
        public async Task<IActionResult> EditHRManager(string id)
        {
            var manager = await _userManager.FindByIdAsync(id);
            
            if (manager!=null)
            {
                var model = new EditManagerModel
                {
                    Id = manager.Id,
                    Email = manager.Email,
                    FirstName = manager.FirstName,
                    LastName = manager.LastName,
                    Phone = manager.PhoneNumber,
                    Username = manager.UserName
                };
                return View(model);
            }

            ModelState.AddModelError(string.Empty, "Not found manager with that id.");
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "SUAdministrator")]
        public async Task<IActionResult> EditAdministrator(string id)
        {
            var manager = await _userManager.FindByIdAsync(id);

            if (manager != null)
            {
                var model = new EditAdministratorModel
                {
                    Id = manager.Id,
                    Email = manager.Email,
                    FirstName = manager.FirstName,
                    LastName = manager.LastName,
                    Phone = manager.PhoneNumber,
                    Username = manager.UserName
                };
                return View(model);
            }

            ModelState.AddModelError(string.Empty, "Not found manager with that id.");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "SUAdministrator")]
        public async Task<IActionResult> EditAdministrator(EditAdministratorModel model)
        {
            var admin = await _userManager.FindByIdAsync(model.Id);

            if (admin != null)
            {
                if (admin.UserName != model.Username)
                {
                    if (await _userManager.FindByNameAsync(model.Username) == null)
                    {
                        admin.UserName = model.Username;
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Username already exists");
                        return View(model);
                    }
                }
                if (admin.Email != model.Email)
                {
                    admin.Email = model.Email;
                }

                if (admin.FirstName != model.FirstName)
                {
                    admin.FirstName = model.FirstName;
                }

                if (admin.LastName != model.LastName)
                {
                    admin.LastName = model.LastName;
                }

                if (admin.PhoneNumber != model.Phone)
                {
                    admin.PhoneNumber = model.Phone;
                }

                await _userManager.UpdateAsync(admin);
                _logger.LogInformation("Admin profile has been updated");
                StatusMessage = "Admin profile has been updated";

                return RedirectToAction("AllAdministrators");
            }

            ModelState.AddModelError(string.Empty, "Not found administrator with that id.");
            return RedirectToAction("AllAdministrators");
        }

        [HttpPost]
        [Authorize(Roles = "SUAdministrator, Administrator")]
        public async Task<IActionResult> EditHRManager(EditManagerModel model)
        {
            var manager = await _userManager.FindByIdAsync(model.Id);

            if (manager != null)
            {
                if (manager.UserName != model.Username)
                {
                    if (await _userManager.FindByNameAsync(model.Username) == null)
                    {
                        manager.UserName = model.Username;
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Username already exists");
                        return View(model);
                    }
                }

                if (manager.Email != model.Email)
                {
                    manager.Email = model.Email;
                }

                if (manager.FirstName != model.FirstName)
                {
                    manager.FirstName = model.FirstName;
                }

                if (manager.LastName != model.LastName)
                {
                    manager.LastName = model.LastName;
                }

                if (manager.PhoneNumber != model.Phone)
                {
                    manager.PhoneNumber = model.Phone;
                }

                await _userManager.UpdateAsync(manager);
                _logger.LogInformation("Manager profile has been updated");
                StatusMessage = "Manager profile has been updated";

                return RedirectToAction("AllManagers");
            }

            ModelState.AddModelError(string.Empty, "Not found manager with that id.");
            return RedirectToAction("AllManagers");
        }

        [HttpGet]
        [Authorize(Roles = "SUAdministrator, Administrator")]
        public async Task<IActionResult> ChangePassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var model = new ChangePasswordModel
                {
                    Id = user.Id
                };
                return View(model);
            }
            ModelState.AddModelError(string.Empty, "Not found user.");
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        [Authorize(Roles = "SUAdministrator, Administrator")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation($"Reset password for user ({user.UserName})");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while trying to change the password.");
                }
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "Not found user.");
            return RedirectToAction("Index", "Home");
        }

        //Todo
        [HttpPost]
        [Authorize(Roles = "SUAdministrator, Administrator")]
        public async Task<IActionResult> LockAccount(string id)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser == null)
            {
                ModelState.AddModelError(string.Empty,"Current user not found.");
                return RedirectToAction("Index","Home");
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return RedirectToAction("Index", "Home");
            }

            if (await _userManager.IsInRoleAsync(user, "SUAdministrator") && !await _userManager.IsInRoleAsync(user,"SUAdministrator"))
            {
                user.LockoutEnd = DateTime.Now.AddYears(100);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index","Home");
            }

            if (await _userManager.IsInRoleAsync(user, "Administrator") 
                && !await _userManager.IsInRoleAsync(user, "SUAdministrator") 
                && !await _userManager.IsInRoleAsync(user,"Administrator"))
            {
                user.LockoutEnd = DateTime.Now.AddYears(100);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "Current user has no permission for lock account.");
            return RedirectToAction("Index", "Home");
        }

        //Todo
        [HttpPost]
        [Authorize(Roles = "SUAdministrator, Administrator")]
        public async Task<IActionResult> UnlockAccount(string id)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser == null)
            {
                ModelState.AddModelError(string.Empty, "Current user not found.");
                return RedirectToAction("Index", "Home");
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return RedirectToAction("Index", "Home");
            }

            if (await _userManager.IsInRoleAsync(user, "SUAdministrator") && !await _userManager.IsInRoleAsync(user, "SUAdministrator"))
            {
                user.LockoutEnd = DateTime.Now;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Home");
            }

            if (await _userManager.IsInRoleAsync(user, "Administrator")
                && !await _userManager.IsInRoleAsync(user, "SUAdministrator")
                && !await _userManager.IsInRoleAsync(user, "Administrator"))
            {
                user.LockoutEnd = DateTime.Now;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "Current user has no permission for unlock account.");
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> PersonalProfile()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            return View(currentUser);
        }

        [HttpGet]
        public async Task<ActionResult> UploadPhotoModal(Guid id)
        {
            ViewBag.UserId = id;
            if (id != Guid.Empty)
                return PartialView("UploadPhotoModal");
            return RedirectToAction("PersonalProfile");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UploadPhoto([FromForm]UploadFileViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return RedirectToAction("Index","Home");
            }
            if (model.File != null)
            {
                
                var path = "/Photo/" + user.Id + model.File.FileName;
                
                using (var fileStream = new FileStream(_webHost.WebRootPath + path, FileMode.Create))
                {
                    await model.File.CopyToAsync(fileStream);
                    user.Photo = path;
                    await _userManager.UpdateAsync(user);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error uploading photo");
            }

            return RedirectToAction("PersonalProfile");
        }
    }
}