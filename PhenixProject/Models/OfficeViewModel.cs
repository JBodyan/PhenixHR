using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PhenixProject.Models
{
    public class OfficeViewModel
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string FullAddress => string.Join(",", City, Address);

        public ICollection<MemberViewModel> Members { get; set; }
        public ICollection<DepartmentViewModel> Departments { get; set; }
    }
}
