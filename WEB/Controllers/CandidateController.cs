using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class CandidateController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;
        public CandidateController(IMemberService service, IMapper mapper)
        {
            _memberService = service;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<CandidateViewModel> candidates;
            try
            {
                 var models = await _memberService.GetMembersAsync();
                 candidates = _mapper.Map<IEnumerable<CandidateViewModel>>(models);
            }
            catch(Exception ex)
            {
                ViewBag.Error = new ErrorViewModel { Message = ex.Message };
                return View();
            }
            return View(candidates);
        }

        public async Task<IActionResult> CandidateDetails(Guid id)
        {
            CandidateViewModel candidate;
            try
            {
                var model = await _memberService.GetMemberByIdAsync(id);
                candidate = _mapper.Map<CandidateViewModel>(model);
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel { Message = ex.Message };
                return View();
            }
            return View(candidate);
        }

        public IActionResult AddCandidate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidate(CandidateViewModel model)
        {
            try
            {
                var member = _mapper.Map<MemberDTO>(model);
                member.IsCandidate = true;
                await _memberService.AddMemberAsync(member);
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel { Message = ex.Message };
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}