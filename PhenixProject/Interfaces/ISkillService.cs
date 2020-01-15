using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhenixProject.Models;

namespace PhenixProject.Interfaces
{
    public interface ISkillService
    {
        Task AddSkillAsync(Guid memberId, SkillViewModel model);
        SkillViewModel GetSkillById(Guid id);
        Task<SkillViewModel> GetSkillByIdAsync(Guid id);
        Task<IEnumerable<SkillViewModel>> GetSkillsByMemberIdAsync(Guid id);
        void UpdateSkill(SkillViewModel skill);
        Task UpdateSkillAsync(SkillViewModel skill);
        Task RemoveSkillAsync(Guid id);
        void Dispose();
    }
}
