using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class DepartmentViewModel
    {
        public string Name { get; set; }
        public ICollection<PositionViewModel> Positions { get; set; }
    }
}
