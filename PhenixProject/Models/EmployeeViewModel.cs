using System;
using System.Collections.Generic;
using System.Text;

namespace PhenixProject.Models
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }
        public OfficeViewModel Office { get; set; }
        public DepartmentViewModel Department { get; set; }
        public PositionViewModel Position { get; set; }
        public PayrollViewModel Payroll { get; set; }
        public HistoryViewModel History { get; set; }
        public PersonalInfoViewModel PersonalInfo { get; set; }
        public ICollection<LeaveViewModel> Leaves { get; set; }
        public ICollection<LinkViewModel> Links { get; set; }
        public ICollection<SkillViewModel> Skills { get; set; }

    }
}
