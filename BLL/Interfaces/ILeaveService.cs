using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    interface ILeaveService
    {
        LeaveDTO GetLeaveById(Guid leaveId);
        Task<LeaveDTO> GetLeaveByIdAsync(Guid leaveId);
        IEnumerable<LeaveDTO> GetLeavesByMemberId(Guid memberId);
        Task<IEnumerable<LeaveDTO>> GetLeavesByMemberIdAsync(Guid memberId);
        void AddLeave(Guid memberId, LeaveDTO leave);
        Task AddLeaveAsync(Guid memberId, LeaveDTO leave);
        void UpdateLeave(LeaveDTO leave);
        Task UpdateLeaveAsync(LeaveDTO leave);
        void Dispose();
    }
}
