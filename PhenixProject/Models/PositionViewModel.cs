using System;
using System.Collections.Generic;
using System.Text;

namespace PhenixProject.Models
{
    public class PositionViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DepartmentIdentifier { get; set; }
        public Guid OfficeIdentifier { get; set; }
    }
}
