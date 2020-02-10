using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhenixProject.Interfaces;
using PhenixProject.Models;

namespace PhenixProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly INewsService _newsService;
        public HomeController(INewsService newsService)
        {
            _newsService = newsService;
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
