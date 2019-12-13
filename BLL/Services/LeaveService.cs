using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Repositories.Interfaces;

namespace BLL.Services
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
        public LeaveDTO GetLeaveById(Guid leaveId)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveDTO> GetLeaveByIdAsync(Guid leaveId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LeaveDTO> GetLeavesByMemberId(Guid memberId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LeaveDTO>> GetLeavesByMemberIdAsync(Guid memberId)
        {
            throw new NotImplementedException();
        }

        public void AddLeave(Guid memberId, LeaveDTO leave)
        {
            throw new NotImplementedException();
        }

        public Task AddLeaveAsync(Guid memberId, LeaveDTO leave)
        {
            throw new NotImplementedException();
        }

        public void UpdateLeave(LeaveDTO leave)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLeaveAsync(LeaveDTO leave)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
