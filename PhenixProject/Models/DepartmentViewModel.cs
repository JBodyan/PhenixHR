using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PhenixProject.Models
{
    public class DepartmentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<PositionViewModel> Positions { get; set; }
        public Guid OfficeIdentifier { get; set; }
    }
}
