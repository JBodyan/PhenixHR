using AutoMapper;
using BLL.DTO;
using BLL.DTO.Contacts;
using BLL.DTO.Information;
using BLL.ExceptionStructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Entities.Contacts;
using DAL.Entities.Information;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public MemberService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _db = unitOfWork;
            _mapper = mapper;
        }

        #region SyncMethods
        public bool AddMember(MemberDTO member)
        {
            try
            {
                var data = _mapper.Map<Member>(member);
                _db.Members.Create(data);
                _db.Save();
            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }

        public MemberDTO GetMemberById(Guid id)
        {
            if (id == null) throw new CustomValidationException("Ιd not specified", "");

            var member = _db.Members.GetById(id);
            if (member == null)
                throw new CustomValidationException("Member not found", "");

            return _mapper.Map<MemberDTO>(member);
        }

        public IEnumerable<MemberDTO> GetMembers()
        {
            var members = _db.Members.GetAll().ToList();
            if (members == null || members.Count < 1) throw new CustomValidationException("No members", "");

            var data = _mapper.Map<IEnumerable<MemberDTO>>(members);
            return data;
        }

        public void UpdateMember(MemberDTO member)
        {
            throw new NotImplementedException();
        }

        public void AttachEmployeeInfo(MemberDTO member)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region AsyncMethods
        public async Task<MemberDTO> GetMemberByIdAsync(Guid id)
        {
            if (id == null) throw new CustomValidationException("Ιd not specified", "");

            var candidate = await _db.Members.GetByIdAsync(id);
            if (candidate == null) throw new CustomValidationException("Member not found", "");

            var data = _mapper.Map<MemberDTO>(candidate);
            return data;
        }

        public async Task<IEnumerable<MemberDTO>> GetMembersAsync()
        {
            var members = (await _db.Members.GetAllAsync()).ToList();
            if (members == null || members.Count < 1) throw new CustomValidationException("No members", "");

            var data = _mapper.Map<IEnumerable<MemberDTO>>(members);
            return data;

        }

        public async Task<bool> AddMemberAsync(MemberDTO member)
        {
            try
            {
                var data = _mapper.Map<Member>(member);
                await _db.Members.CreateAsync(data);
                _db.Save();
            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }

        public async Task UpdateMemberAsync(MemberDTO member)
        {
            var data = _mapper.Map<Member>(member);
            await _db.Members.UpdateAsync(data);
            _db.Save();
        }

        public async Task AttachEmployeeInfoAsync(MemberDTO member)
        {
            var data = await _db.Members.GetByIdAsync(member.Id);
            if(data==null) throw new CustomValidationException("Member not found", "");
            var employeeProfile = _mapper.Map<EmployeeInfo>(member.EmployeeInfo);
            data.EmployeeInfo = employeeProfile;
            data.IsCandidate = false;
            data.IsEmployee = true;
            await _db.Members.UpdateAsync(data);
            _db.Save();
        }
        #endregion

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
