using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhenixProject.Models;

namespace PhenixProject.Interfaces
{
    interface ISkillService
    {
        Task AddSkillAsync(Guid memberId, SkillViewModel model);
        SkillViewModel GetSkillById(Guid id);
        Task<SkillViewModel> GetSkillByIdAsync(Guid id);
        Task<IEnumerable<SkillViewModel>> GetSkillsByMemberIdAsync(Guid id);
        void UpdateSkillById(Guid id, SkillViewModel skill);
        Task UpdateSkillByIdAsync(Guid id, SkillViewModel skill);
        void Dispose();
    }
}
