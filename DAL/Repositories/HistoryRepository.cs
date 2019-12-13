using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class HistoryRepository : IRepository<EmployeeHistory>
    {

        private readonly Data.AppContext _db;

        public HistoryRepository(Data.AppContext appContext)
        {
            _db = appContext;
        }

        public IEnumerable<EmployeeHistory> GetAll()
        {
            return _db.EmployeeHistories;
        }

        public async Task<IEnumerable<EmployeeHistory>> GetAllAsync()
        {
            return _db.EmployeeHistories;
        }

        public EmployeeHistory GetById(Guid id)
        {
            return _db.EmployeeHistories.FirstOrDefault(x=>x.Id == id);
        }

        public async Task<EmployeeHistory> GetByIdAsync(Guid id)
        {
            return await _db.EmployeeHistories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<EmployeeHistory> Find(Func<EmployeeHistory, bool> predicate)
        {
            return _db.EmployeeHistories.Where(predicate);
        }

        public async Task<IEnumerable<EmployeeHistory>> FindAsync(Func<EmployeeHistory, bool> predicate)
        {
            return _db.EmployeeHistories.Where(predicate);
        }

        public void Create(EmployeeHistory item)
        {
            _db.Add(item);
        }

        public async Task CreateAsync(EmployeeHistory item)
        {
            await _db.AddAsync(item);
        }

        public void Update(EmployeeHistory item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public async Task UpdateAsync(EmployeeHistory item)
        {
            _db.Entry(item).State = EntityState.Modified;
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
