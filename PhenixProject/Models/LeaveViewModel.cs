using System;
using System.Collections.Generic;
using System.Text;

namespace PhenixProject.Models
{
    public class LeaveViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalDays { get; set; }
    }
}
