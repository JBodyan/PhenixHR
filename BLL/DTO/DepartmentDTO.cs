using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class DepartmentDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<PositionDTO> Positions { get; set; }
    }
}
