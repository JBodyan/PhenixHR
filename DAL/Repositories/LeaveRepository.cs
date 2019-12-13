using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class LeaveRepository : IRepository<Leave>
    {
        private readonly Data.AppContext _db;

        public LeaveRepository(Data.AppContext appContext)
        {
            _db = appContext;
        }

        public IEnumerable<Leave> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Leave>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Leave GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Leave> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Leave> Find(Func<Leave, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Leave>> FindAsync(Func<Leave, bool> predicate)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Leave item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
