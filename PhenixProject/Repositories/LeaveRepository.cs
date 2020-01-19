using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhenixProject.Entities;
using PhenixProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using PhenixProject.Data;

namespace PhenixProject.Repositories
{
    public class LeaveRepository : IRepository<Leave>
    {
        private readonly AppIdentityDbContext _db;

        public LeaveRepository(AppIdentityDbContext appContext)
        {
            _db = appContext;
        }

        public IEnumerable<Leave> GetAll()
        {
            return _db.Leaves;
        }

        public async Task<IEnumerable<Leave>> GetAllAsync()
        {
            return _db.Leaves;
        }

        public Leave GetById(Guid id)
        {
            return _db.Leaves.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Leave> GetByIdAsync(Guid id)
        {
            return await _db.Leaves.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<Leave> Find(Func<Leave, bool> predicate)
        {
            return _db.Leaves.Where(predicate);
        }

        public async Task<IEnumerable<Leave>> FindAsync(Func<Leave, bool> predicate)
        {
            return _db.Leaves.Where(predicate);
        }

        public void Create(Leave item)
        {
            _db.Leaves.Add(item);
        }

        public async Task CreateAsync(Leave item)
        {
            await _db.Leaves.AddAsync(item);
        }

        public void Update(Leave item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public async Task UpdateAsync(Leave item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _db.Leaves.FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
                _db.Leaves.Remove(entity);
            
        }
    }
}
