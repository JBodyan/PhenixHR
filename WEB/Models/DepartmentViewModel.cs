using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class DepartmentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<PositionViewModel> Positions { get; set; }
        public Guid OfficeIdentifier { get; set; }
    }
}
