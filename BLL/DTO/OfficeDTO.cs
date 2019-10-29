using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class OfficeDTO
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public ICollection<MemberDTO> Members { get; set; }
        public ICollection<DepartmentDTO> Departments { get; set; }
    }
}
