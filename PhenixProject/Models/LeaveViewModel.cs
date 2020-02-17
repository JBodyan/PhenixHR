using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhenixProject.Models
{
    public class LeaveViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        public decimal TotalDays { get; set; }
        public Guid EmployeeId { get; set; }

    }
}
