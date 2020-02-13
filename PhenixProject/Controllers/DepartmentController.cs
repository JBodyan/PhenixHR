using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PhenixProject.Interfaces;

namespace PhenixProject.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IOfficeService _officeService;
        public DepartmentController(IOfficeService officeService)
        {
            _officeService = officeService;
        }
        [HttpGet("GetDepartments/{id}")]
        public async Task<ActionResult> GetDepartments(string id)
        {
            var list = await _officeService.GetDepartmentsByOfficeIdAsync(Guid.Parse(id));
            var json = JsonConvert.SerializeObject(list);
            return Ok(json);
        }

        [HttpGet("GetPositions/{id}")]
        public async Task<ActionResult> GetPositions(string id)
        {
            var list = await _officeService.GetPositionsByDepartmentIdAsync(Guid.Parse(id));
            var json = JsonConvert.SerializeObject(list);
            return Ok(json);
        }
    }
}