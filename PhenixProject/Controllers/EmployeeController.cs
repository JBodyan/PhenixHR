using System;
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
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _webHost;
        public EmployeeController(IMemberService service, IMapper mapper,IHostingEnvironment webHost)
        {
            _memberService = service;
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

        [HttpGet]
        public async Task<IActionResult> EmployeeEdit(Guid id)
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
        public async Task<IActionResult> EmployeeEdit(EmployeeViewModel model)
        {
            try
            {
                await _memberService.UpdateEmployeeInfoAsync(model);

            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel { Message = ex.Message };
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
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

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> UploadPhotoModal(Guid id)
        {
            ViewBag.UserId = id;
            if (id != Guid.Empty)
                return PartialView("UploadPhotoModal");
            return RedirectToAction("Index");
        }
    }
}