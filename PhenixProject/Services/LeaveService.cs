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
    public class LeaveService : ILeaveService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public LeaveService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _db = unitOfWork;
            _mapper = mapper;
        }
        public LeaveViewModel GetLeaveById(Guid leaveId)
        {
            var leave = _db.Leaves.GetById(leaveId);
            return _mapper.Map<LeaveViewModel>(leave);
        }

        public async Task<LeaveViewModel> GetLeaveByIdAsync(Guid leaveId)
        {
            var leave = await _db.Leaves.GetByIdAsync(leaveId);
            return _mapper.Map<LeaveViewModel>(leave);
        }

        public IEnumerable<LeaveViewModel> GetLeavesByMemberId(Guid memberId)
        {
            var member = _db.Members.GetById(memberId);
            return _mapper.Map<IEnumerable<LeaveViewModel>>(member.EmployeeInfo.Leaves);
        }

        public IEnumerable<LeaveViewModel> GetAllLeaves()
        {
            return _mapper.Map<IEnumerable<LeaveViewModel>>(_db.Leaves);
        }

        public async Task<IEnumerable<LeaveViewModel>> GetLeavesByMemberIdAsync(Guid memberId)
        {
            var member = await _db.Members.GetByIdAsync(memberId);
            return _mapper.Map<IEnumerable<LeaveViewModel>>(member.EmployeeInfo.Leaves);
        }

        public void AddLeave(LeaveViewModel model)
        {
            var member = _db.Members.GetById(model.EmployeeId);
            var leave = _mapper.Map<Leave>(model);
            leave.Id = Guid.NewGuid();
            if (member.EmployeeInfo.Leaves == null)
            {
                member.EmployeeInfo.Leaves = new List<Leave>
                {
                    leave
                };
                _db.Members.Update(member);
                _db.Save();
            }
            else
            {
                member.EmployeeInfo.Leaves.Add(leave);
                _db.Members.Update(member);
                _db.Save();
            }
        }

        public async Task AddLeaveAsync(LeaveViewModel model)
        {
            var member = await _db.Members.GetByIdAsync(model.EmployeeId);
            var leave = _mapper.Map<Leave>(model);
            leave.Id = Guid.NewGuid();
            if (member.EmployeeInfo.Leaves == null)
            {
                member.EmployeeInfo.Leaves = new List<Leave>
                {
                    leave
                };
                await _db.Members.UpdateAsync(member);
                _db.Save();
            }
            else
            {
                member.EmployeeInfo.Leaves.Add(leave);
                await _db.Members.UpdateAsync(member);
                _db.Save();
            }
            
        }

        public void UpdateLeave(LeaveViewModel model)
        {
            var leave = _db.Leaves.GetById(model.Id);
            leave.Description = model.Description;
            leave.StartDate = model.StartDate;
            leave.EndDate = model.EndDate;
            leave.TotalDays = model.TotalDays;
            _db.Leaves.Update(leave);
            _db.Save();
        }

        public async Task UpdateLeaveAsync(LeaveViewModel model)
        {
            var leave = await _db.Leaves.GetByIdAsync(model.Id);
            leave.Description = model.Description;
            leave.StartDate = model.StartDate;
            leave.EndDate = model.EndDate;
            leave.TotalDays = model.TotalDays;
            await _db.Leaves.UpdateAsync(leave);
            _db.Save();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task RemoveLeaveAsync(Guid id)
        {
            await _db.Leaves.DeleteAsync(id);
            _db.Save();
        }
    }
}
