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
        bool AddMember(MemberDTO candidate);
        Task<bool> AddMemberAsync(MemberDTO member);
        void Dispose();
    }
}
