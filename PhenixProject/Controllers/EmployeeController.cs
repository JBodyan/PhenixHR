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
using Microsoft.AspNetCore.Mvc.Rendering;
using PhenixProject.Interfaces;
using PhenixProject.Models;
using X.PagedList;

namespace PhenixProject.Controllers
{
    [Authorize(Roles = "HRManager")]
    public class EmployeeController : Controller
    {
        const int PageSize = 3;
        private readonly IMemberService _memberService;
        private readonly IPersonalInfoService _personalInfoService;
        private readonly ISkillService _skillService;
        private readonly IPayrollService _payrollService;
        private readonly ILeaveService _leaveService;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _webHost;
        private readonly ILinkService _linkService;
        private readonly IOfficeService _officeService;
        public EmployeeController(IMemberService service,
            IOfficeService officeService,
            ILinkService linkService,
            ISkillService skillService,
            IPayrollService payrollService,
            ILeaveService leaveService,
            IPersonalInfoService personalInfoService, 
            IMapper mapper,IHostingEnvironment webHost)
        {
            _memberService = service;
            _officeService = officeService;
            _personalInfoService = personalInfoService;
            _payrollService = payrollService;
            _skillService = skillService;
            _linkService = linkService;
            _leaveService = leaveService;
            _mapper = mapper;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index(string searchString,int? page)
        {
            IEnumerable<EmployeeViewModel> employees;
            try
            {
                var models = (await _memberService.GetMembersAsync()).Where(x => x.IsEmployee && !x.IsArchived);
                if (!string.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.ToUpper();
                    models = models.Where(
                        x => x.PersonalInfo.FirstName.ToUpper().Contains(searchString)
                             || x.PersonalInfo.LastName.ToUpper().Contains(searchString)
                             || x.PersonalInfo.MidName.ToUpper().Contains(searchString)
                             || x.EmployeeInfo.Department.Name.ToUpper().Contains(searchString)
                             || x.EmployeeInfo.Position.Name.ToUpper().Contains(searchString)
                    );
                }
                employees = _mapper.Map<IEnumerable<EmployeeViewModel>>(models);
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel { Message = ex.Message };
                return View();
            }
            var pageNumber = (page ?? 1);
            return View(await employees.ToPagedListAsync(pageNumber, PageSize));
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

        [HttpGet]
        public async Task<ActionResult> EditDepartmentModal(Guid employeeId)
        {
            var offices = await _officeService.GetOfficesAsync();
            var model = new EmployeeDepartmentViewModel
            {
                EmployeeId = employeeId
            };
            ViewBag.Offices = new SelectList(offices, "Id", "Address");
            return PartialView("EditDepartmentModal", model);
        }

        [HttpPost]
        public async Task<ActionResult> EditDepartment(EmployeeDepartmentViewModel model)
        {
            var id = model.EmployeeId;
            if (Guid.Empty == model.OfficeId || Guid.Empty == model.DepartmentId || Guid.Empty == model.PositionId)
            {
                ModelState.AddModelError(string.Empty,"Please select data");
                return RedirectToAction("EditDepartmentModal", id);
            }
            await _memberService.UpdateDepartmentAsync(model);
            return RedirectToAction("EmployeeDetails", new { id });
        }

        [HttpPost]
        public async Task<ActionResult> EditPersonalInfo(PersonalInfoViewModel model)
        {
            var id = model.EmployeeId;
            await _personalInfoService.UpdatePersonalInfoByMemberIdAsync(id, model);
            return RedirectToAction("EmployeeDetails", new { id });
        }

        //Links

        #region Links

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

        [HttpPost]
        public async Task<ActionResult> RemoveLink(LinkViewModel model)
        {
            var id = model.EmployeeId;
            await _linkService.RemoveLinkAsync(model.Id);
            return RedirectToAction("EmployeeDetails", new { id });
        }
        #endregion

        //Skills

        #region Skills

        [HttpGet]
        public async Task<ActionResult> EditSkillModal(Guid skillId, Guid employeeId)
        {
            var skill = await _skillService.GetSkillByIdAsync(skillId);
            if (skill == null)
            {
                ModelState.AddModelError(string.Empty, "Skill not found");
                return View("Index");
            }
            ViewBag.EmployeeId = employeeId;
            if (skill.Id != Guid.Empty)
                return PartialView("EditSkillModal", skill);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> EditSkill(SkillViewModel model)
        {
            var id = model.EmployeeId;
            await _skillService.UpdateSkillAsync(model);
            return RedirectToAction("EmployeeDetails", new { id });
        }

        [HttpGet]
        public async Task<ActionResult> AddSkillModal(Guid employeeId)
        {
            var member = await _memberService.GetMemberByIdAsync(employeeId);
            if (member == null)
            {
                ModelState.AddModelError(string.Empty, "Employee not found");
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = employeeId;
            return PartialView("AddSkillModal");
        }
        [HttpPost]
        public async Task<ActionResult> AddSkill(SkillViewModel model)
        {
            var id = model.EmployeeId;
            await _skillService.AddSkillAsync(id, model);
            return RedirectToAction("EmployeeDetails", new { id });
        }

        [HttpPost]
        public async Task<ActionResult> RemoveSkill(SkillViewModel model)
        {
            var id = model.EmployeeId;
            await _skillService.RemoveSkillAsync(model.Id);
            return RedirectToAction("EmployeeDetails", new { id });
        }
        #endregion

        //Payroll

        #region Payroll

        [HttpGet]
        public async Task<ActionResult> EditPayrollModal(Guid payrollId, Guid employeeId)
        {
            var payroll = await _payrollService.GetPayrollByIdAsync(payrollId);
            if (payroll == null)
            {
                ModelState.AddModelError(string.Empty, "Payroll not found");
                return View("Index");
            }
            ViewBag.EmployeeId = employeeId;
            if (payroll.Id != Guid.Empty)
                return PartialView("EditPayrollModal", payroll);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> EditPayroll(PayrollViewModel model)
        {
            var id = model.EmployeeId;
            await _payrollService.UpdatePayrollAsync(model);
            return RedirectToAction("EmployeeDetails", new { id });
        }

        #endregion

        //Leaves

        #region Leaves

        [HttpGet]
        public async Task<ActionResult> EditLeaveModal(Guid leaveId, Guid employeeId)
        {
            var payroll = await _leaveService.GetLeaveByIdAsync(leaveId);
            if (payroll == null)
            {
                ModelState.AddModelError(string.Empty, "Leave not found");
                return View("Index");
            }
            ViewBag.EmployeeId = employeeId;
            if (payroll.Id != Guid.Empty)
                return PartialView("EditLeaveModal", payroll);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> EditLeave(LeaveViewModel model)
        {
            var id = model.EmployeeId;
            await _leaveService.UpdateLeaveAsync(model);
            return RedirectToAction("EmployeeDetails", new { id });
        }

        [HttpGet]
        public async Task<ActionResult> AddLeaveModal(Guid employeeId)
        {
            var member = await _memberService.GetMemberByIdAsync(employeeId);
            if (member == null)
            {
                ModelState.AddModelError(string.Empty, "Employee not found");
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = employeeId;
            return PartialView("AddLeaveModal");
        }
        [HttpPost]
        public async Task<ActionResult> AddLeave(LeaveViewModel model)
        {
            var id = model.EmployeeId;
            await _leaveService.AddLeaveAsync(model);
            return RedirectToAction("EmployeeDetails", new { id });
        }

        [HttpPost]
        public async Task<ActionResult> RemoveLeave(LeaveViewModel model)
        {
            var id = model.EmployeeId;
            await _leaveService.RemoveLeaveAsync(model.Id);
            return RedirectToAction("EmployeeDetails", new { id });
        }

        #endregion
    }
}