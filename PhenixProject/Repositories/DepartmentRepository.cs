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
    public class DepartmentRepository : IRepository<Department>
    {

        private readonly AppIdentityDbContext _db;

        public DepartmentRepository(AppIdentityDbContext appContext)
        {
            _db = appContext;
        }

        public IEnumerable<Department> GetAll()
        {
            return _db.Departments;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return _db.Departments;
        }

        public Department GetById(Guid id)
        {
            var department = _db.Departments.FirstOrDefault(x => x.Id == id);
            if (department == null) return department;
            _db.Entry(department).Collection(x => x.Positions).Load();
            return department;
        }

        public async Task<Department> GetByIdAsync(Guid id)
        {
            var department = await _db.Departments.FirstOrDefaultAsync(x => x.Id == id);
            if (department == null) return department;
            await _db.Entry(department).Collection(x => x.Positions).LoadAsync();
            return department;
        }

        public IEnumerable<Department> Find(Func<Department, bool> predicate)
        {
            var departments = _db.Departments.Where(predicate).ToList();
            if (!departments.Any()) return departments;
            foreach (var entity in departments)
            {
                _db.Entry(entity).Collection(x=>x.Positions).Load();
            }
            return departments;
        }

        public async Task<IEnumerable<Department>> FindAsync(Func<Department, bool> predicate)
        {
            var departments = _db.Departments.Where(predicate).ToList();
            if (!departments.Any()) return departments;
            foreach (var entity in departments)
            {
               await _db.Entry(entity).Collection(x => x.Positions).LoadAsync();
            }
            return departments;
        }

        public void Create(Department item)
        {
            _db.Add(item);
        }

        public async Task CreateAsync(Department item)
        {
            await _db.AddAsync(item);
        }

        public void Update(Department item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public async Task UpdateAsync(Department item)
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
