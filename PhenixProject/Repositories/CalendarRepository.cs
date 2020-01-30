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
    public class CalendarRepository : IRepository<CalendarEvent>
    {
        private readonly AppIdentityDbContext _db;

        public CalendarRepository(AppIdentityDbContext appContext)
        {
            _db = appContext;
        }
        public IEnumerable<CalendarEvent> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CalendarEvent>> GetAllAsync()
        {
            return _db.CalendarEvents;
        }

        public CalendarEvent GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CalendarEvent> GetByIdAsync(Guid id)
        {
            return await _db.CalendarEvents.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<CalendarEvent> Find(Func<CalendarEvent, bool> predicate)
        {
            return _db.CalendarEvents.Where(predicate);
        }

        public async Task<IEnumerable<CalendarEvent>> FindAsync(Func<CalendarEvent, bool> predicate)
        {
            return _db.CalendarEvents.Where(predicate);
        }

        public void Create(CalendarEvent item)
        {
            _db.CalendarEvents.Add(item);
        }

        public async Task CreateAsync(CalendarEvent item)
        {
            await _db.CalendarEvents.AddAsync(item);
        }

        public void Update(CalendarEvent item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public async Task UpdateAsync(CalendarEvent item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
