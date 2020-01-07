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

        public void UpdatePayroll(Guid id, PayrollViewModel payroll)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePayrollAsync(Guid id, PayrollViewModel payroll)
        {
            if (id == null) throw new Exception("Ιd not specified");

            var member = await _db.Members.GetByIdAsync(id);
            if (member == null) throw new Exception("Member not found");
            if (!member.IsEmployee) throw new Exception("Member not employee");
            var data = _mapper.Map<Payroll>(payroll);
            member.EmployeeInfo.Payroll.Employment = payroll.Employment;
            member.EmployeeInfo.Payroll.Salary = payroll.Salary;
            await _db.Members.UpdateAsync(member);
            _db.Save();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
