using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PhenixProject.Entities;
using PhenixProject.Interfaces;
using PhenixProject.Models;

namespace PhenixProject.Services
{
    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public SkillService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _db = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddSkillAsync(Guid memberId, SkillViewModel model)
        {
            var member = await _db.Members.GetByIdAsync(memberId);
            var skill = _mapper.Map<Skill>(model);
            skill.Id = Guid.NewGuid();
            if (member.EmployeeInfo.Links == null)
            {
                member.EmployeeInfo.Skills = new List<Skill>
                {
                    skill
                };
                
            }
            else
            {
                member.EmployeeInfo.Skills.Add(skill);
            }
            member.EmployeeInfo.Histories.Add(new EmployeeHistory
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Event = $"Added skill ({skill.Name})"
            });
            _db.Members.Update(member);
            _db.Save();
        }

        public SkillViewModel GetSkillById(Guid id)
        {
            var skill = _db.Skills.GetById(id);
            return _mapper.Map<SkillViewModel>(skill);
        }

        public async Task<SkillViewModel> GetSkillByIdAsync(Guid id)
        {
            var skill = await _db.Skills.GetByIdAsync(id);
            return _mapper.Map<SkillViewModel>(skill);
        }

        public async Task<IEnumerable<SkillViewModel>> GetSkillsByMemberIdAsync(Guid id)
        {
            var member = await _db.Members.GetByIdAsync(id);
            return _mapper.Map<IEnumerable<SkillViewModel>>(member.EmployeeInfo.Skills);
        }

        public void UpdateSkill(SkillViewModel skill)
        {
            var model = _db.Skills.GetById(skill.Id);
            model.Name = skill.Name;
            model.Description = skill.Description;
            model.Level = skill.Level;
            _db.Skills.Update(model);
            _db.Save();
        }

        public async Task UpdateSkillAsync(SkillViewModel skill)
        {
            var model = _db.Skills.GetById(skill.Id);
            model.Name = skill.Name;
            model.Description = skill.Description;
            model.Level = skill.Level;
            await _db.Skills.UpdateAsync(model);
            _db.Save();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task RemoveSkillAsync(Guid id)
        {
            await _db.Skills.DeleteAsync(id);
            _db.Save();
        }
    }
}
