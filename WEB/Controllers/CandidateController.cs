using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ICandidateService _candidateService;
        public CandidateController(ICandidateService service)
        {
            _candidateService = service;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<CandidateDTO> candidates;
            try
            {
                 candidates = _candidateService.GetCandidates();
            }
            catch(Exception ex)
            {
                ViewBag.Error = new ErrorViewModel { Message = ex.Message };
                return View();
            }
            return View(candidates);
        }
    }
}