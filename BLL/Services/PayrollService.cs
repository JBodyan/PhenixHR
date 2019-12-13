using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.ExceptionStructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services
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

        public PayrollDTO GetPayrollByMemberId(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PayrollDTO> GetPayrollByMemberIdAsync(Guid id)
        {
            if (id == null) throw new CustomValidationException("Ιd not specified", "");

            var member = await _db.Members.GetByIdAsync(id);
            if (member == null) throw new CustomValidationException("Member not found", "");
            if (!member.IsEmployee) throw new CustomValidationException("Member not employee", "");
            var data = _mapper.Map<PayrollDTO>(member.EmployeeInfo.Payroll);
            return data;
        }

        public void UpdatePayroll(Guid id, PayrollDTO payroll)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePayrollAsync(Guid id, PayrollDTO payroll)
        {
            if (id == null) throw new CustomValidationException("Ιd not specified", "");

            var member = await _db.Members.GetByIdAsync(id);
            if (member == null) throw new CustomValidationException("Member not found", "");
            if (!member.IsEmployee) throw new CustomValidationException("Member not employee", "");
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
