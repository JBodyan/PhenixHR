using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    interface IPayrollService
    {
        PayrollDTO GetPayrollByMemberId(Guid id);
        Task<PayrollDTO> GetPayrollByMemberIdAsync(Guid id);
        void UpdatePayroll(Guid id, PayrollDTO payroll);
        Task UpdatePayrollAsync(Guid id, PayrollDTO payroll);
        void Dispose();
    }
}
