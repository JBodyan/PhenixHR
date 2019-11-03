using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }
        public OfficeViewModel Office { get; set; }
        public DepartmentViewModel Department { get; set; }
        public PositionViewModel Position { get; set; }
        public PayrollViewModel Payroll { get; set; }
        public HistoryViewModel History { get; set; }
        public ICollection<LeaveViewModel> Leaves { get; set; }
        public PersonalnfoViewModel PersonalInfo { get; set; }
    }
}
