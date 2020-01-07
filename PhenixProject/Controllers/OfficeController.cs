using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhenixProject.Entities;
using PhenixProject.Interfaces;
using PhenixProject.Models;

namespace PhenixProject.Controllers
{
    [Authorize(Roles = "SUAdministrator, Administrator")]
    public class OfficeController : Controller
    {
        private readonly IOfficeService _officeService;
        private readonly IMapper _mapper;
        public OfficeController(IOfficeService service, IMapper mapper)
        {
            _officeService = service;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<OfficeViewModel> offices;
            try
            {
                var models = await _officeService.GetOfficesAsync();
                offices = _mapper.Map<IEnumerable<OfficeViewModel>>(models);
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel { Message = ex.Message };
                return View();
            }
            return View(offices);
        }

        [HttpGet]
        public IActionResult AddOffice()
        {
            return View();
        }

        public async Task<IActionResult> OfficeDetails(Guid id)
        {

            OfficeViewModel office;
            try
            {
                var model = await _officeService.GetOfficeByIdAsync(id);
                office = _mapper.Map<OfficeViewModel>(model);
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel { Message = ex.Message };
                return View();
            }
            return View(office);
        }

        [HttpPost]
        public async Task<IActionResult> AddOffice(OfficeViewModel model)
        {
            try
            {
                await _officeService.AddOfficeAsync(model);
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel { Message = ex.Message };
                return View();
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> AddDepartment(Guid id)
        {
            ViewBag.OfficeId = id;
            if (id != Guid.Empty)
                return PartialView("AddDepartmentModal");
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> AddPosition(Guid officeId, Guid departmentId)
        {
            ViewBag.OfficeId = officeId;
            ViewBag.DepartmentId = departmentId;
            if (departmentId != Guid.Empty && officeId != Guid.Empty)
                return PartialView("AddPositionModal");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentViewModel model)
        {
            try
            {
                model.Id = Guid.Empty;
                await _officeService.AddDepartmentByOfficeIdAsync(model.OfficeIdentifier, model);
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel { Message = ex.Message };
                return RedirectToAction("OfficeDetails", new { id = model.OfficeIdentifier });
            }
            return RedirectToAction("OfficeDetails", new { id = model.OfficeIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> AddPosition(PositionViewModel model)
        {
            try
            {
                await _officeService.AddPositionByDepartmentIdAsync(model.DepartmentIdentifier, model);
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel { Message = ex.Message };
                return RedirectToAction("OfficeDetails", new { id = model.OfficeIdentifier });
            }
            return RedirectToAction("OfficeDetails", new { id = model.OfficeIdentifier });
        }
    }
}