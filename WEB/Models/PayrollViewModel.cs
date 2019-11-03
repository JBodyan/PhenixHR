using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Resources.Enums;

namespace WEB.Models
{
    public class PayrollViewModel
    {
        public Employment Employment { get; set; }
        public decimal Salary { get; set; }
    }
}
