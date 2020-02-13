using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PhenixProject.Interfaces;
using PhenixProject.Models;

namespace PhenixProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly INewsService _newsService;
        private readonly IHostingEnvironment _webHost;
        public HomeController(INewsService newsService, IHostingEnvironment webHost)
        {
            _newsService = newsService;
            _webHost = webHost;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<NewsPostViewModel> news = null;
            try
            {
                news = await _newsService.GetAllNewsAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty,ex.Message);
            }
            return View(news);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,SUAdministrator")]
        public async Task<IActionResult> AddNews(NewsPostViewModel model)
        {
            try
            {
                var newsPost = new NewsPostViewModel
                {
                    Id = Guid.NewGuid(),
                    Title = model.Title,
                    Description = model.Description,
                    PostedTime = DateTime.Now
                };
                if (model.File != null)
                {
                    var path = "/NewsImages/" + model.File.FileName;

                    using (var fileStream = new FileStream(_webHost.WebRootPath + path, FileMode.Create))
                    {
                        await model.File.CopyToAsync(fileStream);
                        newsPost.ImgPath = path;
                    }
                }
                await _newsService.AddNewsAsync(newsPost);
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel { Message = ex.Message };
                return View("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,SUAdministrator")]
        public async Task<ActionResult> AddNewsModal()
        {
            return PartialView("AddNewsModal");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,SUAdministrator")]
        public async Task<ActionResult> EditNewsModal()
        {
            return PartialView("AddNewsModal");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
