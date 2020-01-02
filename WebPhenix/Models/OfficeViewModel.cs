using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPhenix.Models
{
    public class OfficeViewModel
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public ICollection<DepartmentViewModel> Departments { get; set; }
    }
}
