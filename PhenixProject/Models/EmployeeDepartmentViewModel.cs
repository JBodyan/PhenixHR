using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PhenixProject.Models
{
    public class EmployeeDepartmentViewModel
    {
        [Required]
        public Guid EmployeeId { get; set; }
        [Required]
        public Guid OfficeId { get; set; }
        [Required]
        public Guid DepartmentId { get; set; }
        [Required]
        public Guid PositionId { get; set; }
    }
}
