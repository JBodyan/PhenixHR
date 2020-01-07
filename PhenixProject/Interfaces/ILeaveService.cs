using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PhenixProject.Models;

namespace PhenixProject.Interfaces
{
    interface ILeaveService
    {
        LeaveViewModel GetLeaveById(Guid leaveId);
        Task<LeaveViewModel> GetLeaveByIdAsync(Guid leaveId);
        IEnumerable<LeaveViewModel> GetLeavesByMemberId(Guid memberId);
        Task<IEnumerable<LeaveViewModel>> GetLeavesByMemberIdAsync(Guid memberId);
        void AddLeave(Guid memberId, LeaveViewModel leave);
        Task AddLeaveAsync(Guid memberId, LeaveViewModel leave);
        void UpdateLeave(LeaveViewModel leave);
        Task UpdateLeaveAsync(LeaveViewModel leave);
        void Dispose();
    }
}
