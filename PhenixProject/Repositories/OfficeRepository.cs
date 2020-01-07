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
    public class OfficeRepository : IRepository<Office>
    {
        private readonly AppIdentityDbContext _db;

        public OfficeRepository(AppIdentityDbContext appContext)
        {
            _db = appContext;
        }

        public void Create(Office item)
        {
            _db.Offices.Add(item);
        }

        public async Task CreateAsync(Office item)
        {
            await _db.Offices.AddAsync(item);
        }

        public void Delete(Guid id)
        {
            
        }

        public async Task DeleteAsync(Guid id)
        {
            
        }

        public IEnumerable<Office> Find(Func<Office, bool> predicate)
        {
            var offices = _db.Offices.Where(predicate).ToList();
            if (!offices.Any()) return offices;
            foreach (var entity in offices)
            {
                _db.Entry(entity).Collection(x => x.Members).Load();
                _db.Entry(entity).Collection(x => x.Departments).Load();
                foreach (var department in entity.Departments)
                {
                    _db.Entry(department).Collection(x => x.Positions).Load();
                }
            }
            return offices;
        }

        public async Task<IEnumerable<Office>> FindAsync(Func<Office, bool> predicate)
        {
            var offices = _db.Offices.Where(predicate).ToList();
            if (!offices.Any()) return offices;
            foreach (var entity in offices)
            {
                await _db.Entry(entity).Collection(x => x.Members).LoadAsync();
                await _db.Entry(entity).Collection(x => x.Departments).LoadAsync();
                foreach (var department in entity.Departments)
                {
                    await _db.Entry(department).Collection(x => x.Positions).LoadAsync();
                }
            }
            return offices;
        }

        public IEnumerable<Office> GetAll()
        {
            var offices = _db.Offices;
            if (!offices.Any()) return offices;
            foreach (var entity in offices)
            {
                _db.Entry(entity).Collection(x => x.Members).Load();
                _db.Entry(entity).Collection(x => x.Departments).Load();
                foreach (var department in entity.Departments)
                {
                    _db.Entry(department).Collection(x => x.Positions).Load();
                }
            }
            return offices;
        }

        public async Task<IEnumerable<Office>> GetAllAsync()
        {
            var offices = _db.Offices;
            if (!offices.Any()) return offices;
            foreach (var entity in offices)
            {
                await _db.Entry(entity).Collection(x => x.Members).LoadAsync();
                await _db.Entry(entity).Collection(x => x.Departments).LoadAsync();
                foreach (var department in entity.Departments)
                {
                    await _db.Entry(department).Collection(x => x.Positions).LoadAsync();
                }
            }
            return offices;
        }

        public Office GetById(Guid id)
        {
            var office = _db.Offices.FirstOrDefault(x => x.Id == id);
            if (office == null) return null;
            _db.Entry(office).Collection(x => x.Members).Load();
            _db.Entry(office).Collection(x => x.Departments).Load();
            foreach (var department in office.Departments)
            {
                _db.Entry(department).Collection(x => x.Positions).Load();
            }
            return office;
        }

        public async Task<Office> GetByIdAsync(Guid id)
        {
            var office = await _db.Offices.FirstOrDefaultAsync(x => x.Id == id);
            if (office == null) return null;
            await _db.Entry(office).Collection(x => x.Members).LoadAsync();
            await _db.Entry(office).Collection(x => x.Departments).LoadAsync();
            foreach (var department in office.Departments)
            {
                await _db.Entry(department).Collection(x=>x.Positions).LoadAsync();
            }
            return office;
        }

        public void Update(Office item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public async Task UpdateAsync(Office item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
