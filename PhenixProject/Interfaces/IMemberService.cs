using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PhenixProject.Models;

namespace PhenixProject.Interfaces
{
    public interface IMemberService
    {
        MemberViewModel GetMemberById(Guid id);
        Task<MemberViewModel> GetMemberByIdAsync(Guid id);
        IEnumerable<MemberViewModel> GetMembers();
        Task<IEnumerable<MemberViewModel>> GetMembersAsync();
        bool AddMember(MemberViewModel member);
        Task<bool> AddMemberAsync(MemberViewModel member);
        void UpdateMember(MemberViewModel member);
        Task UpdateMemberAsync(MemberViewModel member);
        void AttachEmployeeInfo(MemberViewModel member);
        Task AttachEmployeeInfoAsync(MemberViewModel member);
        void Dispose();
    }
}
