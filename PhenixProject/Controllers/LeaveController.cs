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
    public class LeaveController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly ILeaveService _leaveService;
        private readonly IMapper _mapper;
        public LeaveController(IMemberService service, ILeaveService leaveService, IMapper mapper)
        {
            _memberService = service;
            _leaveService = leaveService;
            _mapper = mapper;
        }

    }
}