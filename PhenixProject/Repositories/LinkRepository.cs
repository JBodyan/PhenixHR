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
    public class LinkRepository : IRepository<Link>
    {
        private readonly AppIdentityDbContext _db;

        public LinkRepository(AppIdentityDbContext appContext)
        {
            _db = appContext;
        }

        public IEnumerable<Link> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Link>> GetAllAsync()
        {
            return _db.Links;
        }

        public Link GetById(Guid id)
        {
            return _db.Links.FirstOrDefault(x=>x.Id == id);
        }

        public async Task<Link> GetByIdAsync(Guid id)
        {
            return await _db.Links.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<Link> Find(Func<Link, bool> predicate)
        {
            return _db.Links.Where(predicate);
        }

        public async Task<IEnumerable<Link>> FindAsync(Func<Link, bool> predicate)
        {
            return _db.Links.Where(predicate);
        }

        public void Create(Link item)
        {
            _db.Links.Add(item);
        }

        public async Task CreateAsync(Link item)
        {
            await _db.Links.AddAsync(item);
        }

        public void Update(Link item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public async Task UpdateAsync(Link item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            var link = await _db.Links.FirstOrDefaultAsync(x=>x.Id == id);
            if (link != null)
                _db.Links.Remove(link);
        }
    }
}
