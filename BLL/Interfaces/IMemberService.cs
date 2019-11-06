using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMemberService
    {
        MemberDTO GetMemberById(Guid id);
        Task<MemberDTO> GetMemberByIdAsync(Guid id);
        IEnumerable<MemberDTO> GetMembers();
        Task<IEnumerable<MemberDTO>> GetMembersAsync();
        bool AddMember(MemberDTO member);
        Task<bool> AddMemberAsync(MemberDTO member);
        void UpdateMember(MemberDTO member);
        Task UpdateMemberAsync(MemberDTO member);
        void AttachEmployeeInfo(MemberDTO member);
        Task AttachEmployeeInfoAsync(MemberDTO member);
        void Dispose();
    }
}
