using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhenixProject.Data;
using PhenixProject.Entities;
using PhenixProject.Interfaces;

namespace PhenixProject.Repositories
{
    public class SkillRepository : IRepository<Skill>
    {
        private readonly AppIdentityDbContext _db;

        public SkillRepository(AppIdentityDbContext appContext)
        {
            _db = appContext;
        }
        public IEnumerable<Skill> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Skill>> GetAllAsync()
        {
            return _db.Skills;
        }

        public Skill GetById(Guid id)
        {
            return _db.Skills.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Skill> GetByIdAsync(Guid id)
        {
            return await _db.Skills.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<Skill> Find(Func<Skill, bool> predicate)
        {
            return _db.Skills.Where(predicate);
        }

        public async Task<IEnumerable<Skill>> FindAsync(Func<Skill, bool> predicate)
        {
            return _db.Skills.Where(predicate);
        }

        public void Create(Skill item)
        {
            _db.Skills.Add(item);
        }

        public async Task CreateAsync(Skill item)
        {
            await _db.Skills.AddAsync(item);
        }

        public void Update(Skill item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public async Task UpdateAsync(Skill item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            var skill = await _db.Skills.FirstOrDefaultAsync(x => x.Id == id);
            if (skill != null)
                _db.Skills.Remove(skill);
        }
    }
}
