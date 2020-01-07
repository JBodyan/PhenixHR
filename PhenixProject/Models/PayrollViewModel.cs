using Resources.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhenixProject.Models
{
    public class PayrollViewModel
    {
        public Guid Id { get; set; }
        public Employment Employment { get; set; }
        public decimal Salary { get; set; }
    }
}
