using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PhenixProject.Models
{
    public class EmployeeDepartmentViewModel
    {
        public Guid EmployeeId { get; set; }
        public Guid OfficeId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid PositionId { get; set; }
    }
}
