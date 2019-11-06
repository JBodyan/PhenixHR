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
    public class OfficeRepository : IRepository<Office>
    {
        private readonly Data.AppContext _db;

        public OfficeRepository(Data.AppContext appContext)
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
                _db.Entry(entity).Reference(x => x.Members).Load();
                _db.Entry(entity).Reference(x => x.Departments).Load();
            }
            return offices;
        }

        public async Task<IEnumerable<Office>> FindAsync(Func<Office, bool> predicate)
        {
            var offices = _db.Offices.Where(predicate).ToList();
            if (!offices.Any()) return offices;
            foreach (var entity in offices)
            {
                _db.Entry(entity).Reference(x => x.Members).Load();
                _db.Entry(entity).Reference(x => x.Departments).Load();
            }
            return offices;
        }

        public IEnumerable<Office> GetAll()
        {
            var offices = _db.Offices;
            if (!offices.Any()) return offices;
            foreach (var entity in offices)
            {
                _db.Entry(entity).Reference(x => x.Members).Load();
                _db.Entry(entity).Reference(x => x.Departments).Load();
            }
            return offices;
        }

        public async Task<IEnumerable<Office>> GetAllAsync()
        {
            var offices = _db.Offices;
            if (!offices.Any()) return offices;
            foreach (var entity in offices)
            {
                _db.Entry(entity).Reference(x => x.Members).Load();
                _db.Entry(entity).Reference(x => x.Departments).Load();
            }
            return offices;
        }

        public Office GetById(Guid id)
        {
            var office = _db.Offices.FirstOrDefault(x => x.Id == id);
            if (office == null) return null;
            _db.Entry(office).Reference(x => x.Members).Load();
            _db.Entry(office).Reference(x => x.Departments).Load();
            return office;
        }

        public async Task<Office> GetByIdAsync(Guid id)
        {
            var office = await _db.Offices.FirstOrDefaultAsync(x => x.Id == id);
            if (office == null) return null;
            _db.Entry(office).Reference(x => x.Members).Load();
            _db.Entry(office).Reference(x => x.Departments).Load();
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
