using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        public EmployeeController(IMemberService service, IMapper mapper)
        {
            _memberService = service;
            _mapper = mapper;
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
                var member = await _memberService.GetMemberByIdAsync(model.Id);

                member.PersonalInfo.FirstName = !string.IsNullOrEmpty(model.PersonalInfo.FirstName) ? member.PersonalInfo.FirstName : string.Empty;
                member.PersonalInfo.MidName = !string.IsNullOrEmpty(model.PersonalInfo.MidName) ? member.PersonalInfo.MidName : string.Empty;
                member.PersonalInfo.LastName = !string.IsNullOrEmpty(model.PersonalInfo.LastName) ? member.PersonalInfo.LastName : string.Empty;
                member.PersonalInfo.BirthDate = model.PersonalInfo.BirthDate;
                member.PersonalInfo.Gender = model.PersonalInfo.Gender;
                member.PersonalInfo.Contacts.Email.Value = !string.IsNullOrEmpty(model.PersonalInfo.Contacts.Email.Value) ? model.PersonalInfo.Contacts.Email.Value : string.Empty;
                member.PersonalInfo.Contacts.Address.Value = !string.IsNullOrEmpty(model.PersonalInfo.Contacts.Address.Value) ? model.PersonalInfo.Contacts.Address.Value : string.Empty;
                member.PersonalInfo.Contacts.Phone.Value = !string.IsNullOrEmpty(model.PersonalInfo.Contacts.Phone.Value) ? model.PersonalInfo.Contacts.Phone.Value : string.Empty;
                member.PersonalInfo.Contacts.SecondPhone.Value = !string.IsNullOrEmpty(model.PersonalInfo.Contacts.SecondPhone.Value) ? model.PersonalInfo.Contacts.SecondPhone.Value : string.Empty;
                member.PersonalInfo.Contacts.Skype.Value = !string.IsNullOrEmpty(model.PersonalInfo.Contacts.Skype.Value) ? model.PersonalInfo.Contacts.Skype.Value : string.Empty;
                member.EmployeeInfo.Payroll.Employment = model.Payroll.Employment;
                member.EmployeeInfo.Payroll.Salary = model.Payroll.Salary;
                member.EmployeeInfo.Department = model.Department;
                member.EmployeeInfo.Position = model.Position;
                await _memberService.UpdateMemberAsync(member);
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