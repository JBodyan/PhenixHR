using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PhenixProject.Models;

namespace PhenixProject.Interfaces
{
    interface IPayrollService
    {
        PayrollViewModel GetPayrollByMemberId(Guid id);
        Task<PayrollViewModel> GetPayrollByMemberIdAsync(Guid id);
        void UpdatePayroll(Guid id, PayrollViewModel payroll);
        Task UpdatePayrollAsync(Guid id, PayrollViewModel payroll);
        void Dispose();
    }
}
