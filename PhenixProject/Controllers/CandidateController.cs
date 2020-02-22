using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhenixProject.Entities;
using PhenixProject.Interfaces;
using PhenixProject.Models;
using Resources.Enums;
using X.PagedList;

namespace PhenixProject.Controllers
{
    [Authorize(Roles = "HRManager")]
    public class CandidateController : Controller
    {
        private const int PageSize = 3;
        private readonly IMemberService _memberService;
        private readonly IOfficeService _officeService;
        private readonly IHistoryService _historyService;
        private readonly IFilterService _filterService;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _webHost;
        private readonly IMimeMappingService _mimeMappingService;
        public CandidateController(IHostingEnvironment webHost,IMemberService service,IFilterService filterService,IHistoryService historyService,IOfficeService officeService, IMapper mapper,IMimeMappingService mimeMappingService)
        {
            _memberService = service;
            _officeService = officeService;
            _historyService = historyService;
            _filterService = filterService;
            _mimeMappingService = mimeMappingService;
            _webHost = webHost;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string searchString, int? page)
        {
            IEnumerable<CandidateViewModel> candidates;
            try
            {
                var models = (await _memberService.GetMembersAsync()).Where(x => x.IsCandidate);
                if (!string.IsNullOrEmpty(searchString))
                {
                    models = models.Where(
                        x => x.PersonalInfo.ToString().Contains(searchString)
                             || x.CandidateInfo.ToString().Contains(searchString)
                             || x.PersonalInfo.Contacts.ToString().Contains(searchString)
                    );
                }
                candidates = _mapper.Map<IEnumerable<CandidateViewModel>>(models);
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel { Message = ex.Message };
                return View();
            }
            var pageNumber = (page ?? 1);
            return View(await candidates.ToPagedListAsync(pageNumber, PageSize));
        }

        [HttpPost]
        public async Task<ActionResult> CandidateSearch(string searchString, int? page, ArchivedFilter archived, GenderFilter gender)
        {
            var models = (await _memberService.GetMembersAsync()).Where(x => x.IsCandidate);
            models = await _filterService.FilterCandidatesAsync(models, gender, archived);

            if (!string.IsNullOrEmpty(searchString))
            {
                models = models.Where(
                    x => x.PersonalInfo.ToString().Contains(searchString)
                         || x.CandidateInfo.ToString().Contains(searchString)
                         || x.PersonalInfo.Contacts.ToString().Contains(searchString)
                );
            }
            var candidates = _mapper.Map<IEnumerable<CandidateViewModel>>(models);
            var pageNumber = (page ?? 1);
            return PartialView("_CandidateSearchPartial",await candidates.ToPagedListAsync(pageNumber, PageSize));
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
        [HttpGet]
        public async Task<IActionResult> TransferToEmployee(Guid id)
        {
            
            EmployeeViewModel employee;
            try
            {
                var model = await _memberService.GetMemberByIdAsync(id);
                employee = _mapper.Map<EmployeeViewModel>(model);
                var offices = await _officeService.GetOfficesAsync();
                ViewBag.Offices = new SelectList(offices, "Id", "FullAddress");
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel { Message = ex.Message };
                return View();
            }
            
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> SendToArchive(Guid id)
        {
            try
            {
                await _memberService.SendToArchive(id);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty,e.Message);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> TransferToEmployee(EmployeeViewModel model)
        {
            try
            {
                var member = _mapper.Map<MemberViewModel>(model);
                await _memberService.AttachEmployeeInfoAsync(member);
                var departmentModel = new EmployeeDepartmentViewModel
                {
                    EmployeeId = model.Id,
                    OfficeId = model.OfficeId,
                    DepartmentId = model.DepartmentId,
                    PositionId = model.PositionId
                };
                await _memberService.UpdateDepartmentAsync(departmentModel);
                await _memberService.AddHistoryAsync(model.Id,new HistoryViewModel
                {
                    Date = DateTime.Now,
                    Event = "Transfered to employee"
                });
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel { Message = ex.Message };
                return View();
            }
            return RedirectToAction("Index", "Employee");
        }

        [HttpGet]
        public async Task<IActionResult> RegisterCandidate()
        {
            ViewBag.Offices = await _officeService.GetOfficesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCandidate([FromForm]CandidateViewModel model)
        {
            try
            {
                if (model.File != null)
                {
                    model.Id = Guid.NewGuid();
                    var path = "/CV/" + model.Id + model.File.FileName;
                    using (var fileStream = new FileStream(_webHost.WebRootPath + path, FileMode.Create))
                    {
                        await model.File.CopyToAsync(fileStream);
                    }
                    model.PathCV = path;
                }
                var member = _mapper.Map<MemberViewModel>(model);
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

        [HttpGet]
        public async Task<ActionResult> DownloadCV(Guid id)
        {
            var candidate = await _memberService.GetMemberByIdAsync(id);
            var path = candidate.CandidateInfo.PathCV;
            if (path != null)
            {
                var mimeType = _mimeMappingService.Map(path);
                var name = string.Join("_", candidate.PersonalInfo.FirstName, candidate.PersonalInfo.LastName, "CV");
                return PhysicalFile(_webHost.WebRootPath + path, mimeType, name);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Path not found");
                return View("Index");
            }
        }
    }
}