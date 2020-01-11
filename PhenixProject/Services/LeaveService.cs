using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
            throw new NotImplementedException();
        }

        public Task<LeaveViewModel> GetLeaveByIdAsync(Guid leaveId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LeaveViewModel> GetLeavesByMemberId(Guid memberId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LeaveViewModel> GetAllLeaves()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LeaveViewModel>> GetLeavesByMemberIdAsync(Guid memberId)
        {
            throw new NotImplementedException();
        }

        public void AddLeave(Guid memberId, LeaveViewModel leave)
        {
            throw new NotImplementedException();
        }

        public Task AddLeaveAsync(Guid memberId, LeaveViewModel leave)
        {
            throw new NotImplementedException();
        }

        public void UpdateLeave(LeaveViewModel leave)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLeaveAsync(LeaveViewModel leave)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
