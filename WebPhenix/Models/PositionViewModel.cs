using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPhenix.Models
{
    public class PositionViewModel
    {
        public string Name { get; set; }
        public Guid DepartmentIdentifier { get; set; }
        public Guid OfficeIdentifier { get; set; }
    }
}
