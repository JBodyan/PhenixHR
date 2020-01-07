using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
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
    }
}