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
    public class PayrollRepository : IRepository<Payroll>
    {

        private readonly AppIdentityDbContext _db;

        public PayrollRepository(AppIdentityDbContext appContext)
        {
            _db = appContext;
        }

        public IEnumerable<Payroll> GetAll()
        {
            return _db.Payrolls;
        }

        public async Task<IEnumerable<Payroll>> GetAllAsync()
        {
            return _db.Payrolls;
        }

        public Payroll GetById(Guid id)
        {
            return _db.Payrolls.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Payroll> GetByIdAsync(Guid id)
        {
            return await _db.Payrolls.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<Payroll> Find(Func<Payroll, bool> predicate)
        {
            return _db.Payrolls.Where(predicate);
        }

        public async Task<IEnumerable<Payroll>> FindAsync(Func<Payroll, bool> predicate)
        {
            return _db.Payrolls.Where(predicate);
        }

        public void Create(Payroll item)
        {
            _db.Add(item);
        }

        public async Task CreateAsync(Payroll item)
        {
            await _db.AddAsync(item);
        }

        public void Update(Payroll item)
        {
            _db.Entry(item).State = EntityState.Modified;

        }

        public async Task UpdateAsync(Payroll item)
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
