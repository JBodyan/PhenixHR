﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhenixProject.Interfaces;
using PhenixProject.Models;

namespace PhenixProject.Controllers
{
    [Authorize(Roles = "HRManager")]
    public class EmployeeController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IPersonalInfoService _personalInfoService;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _webHost;
        private readonly ILinkService _linkService;
        public EmployeeController(IMemberService service,
            ILinkService linkService,
            IPersonalInfoService personalInfoService, 
            IMapper mapper,IHostingEnvironment webHost)
        {
            _memberService = service;
            _personalInfoService = personalInfoService;
            _linkService = linkService;
            _mapper = mapper;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<EmployeeViewModel> employees;
            try
            {
                var models = (await _memberService.GetMembersAsync()).Where(x => x.IsEmployee && !x.IsArchived);
                employees = _mapper.Map<IEnumerable<EmployeeViewModel>>(models);
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel { Message = ex.Message };
                return View();
            }
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeDetails(Guid id)
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
        public async Task<IActionResult> UploadPhoto([FromForm]UploadFileViewModel model)
        {
            var user = await _memberService.GetMemberByIdAsync(Guid.Parse(model.UserId));
            if (user == null)
            {
                ModelState.AddModelError(string.Empty,"User not found");
                return View("Index");
            }
            if (model.File != null)
            {
                
                var path = "/Photo/" + user.Id + model.File.FileName;
                
                using (var fileStream = new FileStream(_webHost.WebRootPath + path, FileMode.Create))
                {
                    await model.File.CopyToAsync(fileStream);
                    await _memberService.UpdatePhotoAsync(user.Id,path);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error uploading photo");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> UploadPhotoModal(Guid id)
        {
            ViewBag.UserId = id;
            if (id != Guid.Empty)
                return PartialView("UploadPhotoModal");
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> EditPersonalInfoModal(Guid employeeId)
        {
            var employee = await _memberService.GetMemberByIdAsync(employeeId);
            if (employee == null)
            {
                ModelState.AddModelError(string.Empty,"Employee not found");
                return View("Index");
            }
            ViewBag.EmployeeId = employeeId;
            if (employee.PersonalInfo.Id != Guid.Empty)
                return PartialView("EditPersonalInfoModal",employee.PersonalInfo);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> EditPersonalInfo(PersonalInfoViewModel model)
        {
            var id = model.EmployeeId;
            await _personalInfoService.UpdatePersonalInfoByMemberIdAsync(id, model);
            return RedirectToAction("EmployeeDetails", new { id });
        }

        [HttpGet]
        public async Task<ActionResult> EditLinkModal(Guid linkId,Guid employeeId)
        {
            var link = await _linkService.GetLinkByIdAsync(linkId);
            if (link == null)
            {
                ModelState.AddModelError(string.Empty, "Link not found");
                return View("Index");
            }
            ViewBag.EmployeeId = employeeId;
            if (link.Id != Guid.Empty)
                return PartialView("EditLinkModal", link);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> EditLink(LinkViewModel model)
        {
            var id = model.EmployeeId;
            await _linkService.UpdateLinkAsync(model);
            return RedirectToAction("EmployeeDetails", new { id });
        }

        [HttpGet]
        public async Task<ActionResult> AddLinkModal(Guid employeeId)
        {
            var member = await _memberService.GetMemberByIdAsync(employeeId);
            if (member == null)
            {
                ModelState.AddModelError(string.Empty, "Employee not found");
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = employeeId;
            return PartialView("AddLinkModal");
        }
        [HttpPost]
        public async Task<ActionResult> AddLink(LinkViewModel model)
        {
            var id = model.EmployeeId;
            await _linkService.AddLinkAsync(id, model);
            return RedirectToAction("EmployeeDetails", new { id });
        }
    }
}