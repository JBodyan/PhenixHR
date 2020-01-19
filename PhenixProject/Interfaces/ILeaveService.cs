using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PhenixProject.Models;

namespace PhenixProject.Interfaces
{
    public interface ILeaveService
    {
        LeaveViewModel GetLeaveById(Guid leaveId);
        Task<LeaveViewModel> GetLeaveByIdAsync(Guid leaveId);
        IEnumerable<LeaveViewModel> GetLeavesByMemberId(Guid memberId);
        IEnumerable<LeaveViewModel> GetAllLeaves();
        Task<IEnumerable<LeaveViewModel>> GetLeavesByMemberIdAsync(Guid memberId);
        void AddLeave(LeaveViewModel model);
        Task AddLeaveAsync(LeaveViewModel model);
        void UpdateLeave(LeaveViewModel model);
        Task UpdateLeaveAsync(LeaveViewModel model);
        Task RemoveLeaveAsync(Guid id);
        void Dispose();
    }
}
