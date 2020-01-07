using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PhenixProject.Models;

namespace PhenixProject.Interfaces
{
    public interface IPersonalInfoService
    {
        PersonalInfoViewModel GetPersonalInfoByMemberId(Guid id);
        Task<PersonalInfoViewModel> GetPersonalInfoByMemberIdAsync(Guid id);
        void UpdatePersonalInfoByMemberId(Guid id, PersonalInfoViewModel personalInfo);
        Task UpdatePersonalInfoByMemberIdAsync(Guid id, PersonalInfoViewModel personalInfo);
        void Dispose();
    }
}
