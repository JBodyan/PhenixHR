using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PhenixProject.Entities;
using PhenixProject.Interfaces;
using PhenixProject.Models;

namespace PhenixProject.Services
{
    public class PayrollService : IPayrollService
    {

        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public PayrollService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _db = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PayrollViewModel> GetPayrollByIdAsync(Guid id)
        {
            var payrolls = await _db.Payrolls.GetByIdAsync(id);
            return _mapper.Map<PayrollViewModel>(payrolls);
        }

        public PayrollViewModel GetPayrollByMemberId(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PayrollViewModel> GetPayrollByMemberIdAsync(Guid id)
        {
            if (id == null) throw new Exception("Ιd not specified");

            var member = await _db.Members.GetByIdAsync(id);
            if (member == null) throw new Exception("Member not found");
            if (!member.IsEmployee) throw new Exception("Member not employee");
            var data = _mapper.Map<PayrollViewModel>(member.EmployeeInfo.Payroll);
            return data;
        }

        public void UpdatePayroll(PayrollViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePayrollAsync(PayrollViewModel model)
        {
            
            var payroll = await _db.Payrolls.GetByIdAsync(model.Id);
            if (payroll == null) throw new Exception("Payroll not found");
            var data = _mapper.Map<Payroll>(payroll);
            payroll.Employment = model.Employment;
            payroll.Salary = model.Salary;
            payroll.Currency = model.Currency;
            await _db.Payrolls.UpdateAsync(payroll);
            _db.Save();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
