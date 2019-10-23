using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IPersonalInfoService
    {
        PersonalInfoDTO GetPersonalInfoByMemberId(Guid id);
        Task<PersonalInfoDTO> GetPersonalInfoByMemberIdAsync(Guid id);
        void UpdatePersonalInfoByMemberId(Guid id,PersonalInfoDTO personalInfo);
        Task UpdatePersonalInfoByMemberIdAsync(Guid id, PersonalInfoDTO personalInfo);
        void Dispose();
    }
}
