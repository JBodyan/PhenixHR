using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PhenixProject.Models;

namespace PhenixProject.Interfaces
{
    public interface IPayrollService
    {
        Task<PayrollViewModel> GetPayrollByIdAsync(Guid id);
        PayrollViewModel GetPayrollByMemberId(Guid id);
        Task<PayrollViewModel> GetPayrollByMemberIdAsync(Guid id);
        void UpdatePayroll(PayrollViewModel model);
        Task UpdatePayrollAsync(PayrollViewModel model);
        void Dispose();
    }
}
