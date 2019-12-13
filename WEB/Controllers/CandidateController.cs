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
                 var models = (await _memberService.GetMembersAsync()).Where(x => x.IsCandidate && !x.IsArchived);
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

        #region TransferCandidate

        public async Task<IActionResult> TransferToEmployee(Guid id)
        {
            EmployeeViewModel employee;
            try
            {
                var model = await _memberService.GetMemberByIdAsync(id);
                employee = _mapper.Map<EmployeeViewModel>(model);
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel { Message = ex.Message };
                return View();
            }
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> TransferToEmployee(EmployeeViewModel model)
        {
            try
            {
                var member = _mapper.Map<MemberDTO>(model);
                await _memberService.AttachEmployeeInfoAsync(member);
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel { Message = ex.Message };
                return View();
            }
            return RedirectToAction("Index", "Employee");
        }

        #endregion

        #region RegistrationCandidate

        [HttpGet]
        public async Task<IActionResult> RegisterCandidate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCandidate(CandidateViewModel model)
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
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        #endregion
    }
}