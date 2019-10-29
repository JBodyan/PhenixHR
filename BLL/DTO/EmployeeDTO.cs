using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public OfficeDTO Office { get; set; }
        public DepartmentDTO Department { get; set; }
        public PositionDTO Position { get; set; }
        public PayrollDTO Payroll { get; set; }
        public HistoryDTO History { get; set; }
        public ICollection<LeaveDTO> Leaves { get; set; }
    }
}
