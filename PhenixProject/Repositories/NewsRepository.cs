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
    public class NewsRepository : IRepository<NewsPost>
    {
        private readonly AppIdentityDbContext _db;

        public NewsRepository(AppIdentityDbContext appContext)
        {
            _db = appContext;
        }
        public IEnumerable<NewsPost> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NewsPost>> GetAllAsync()
        {
            return _db.NewsPosts;
        }

        public NewsPost GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<NewsPost> GetByIdAsync(Guid id)
        {
            return await _db.NewsPosts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<NewsPost> Find(Func<NewsPost, bool> predicate)
        {
            return _db.NewsPosts.Where(predicate);
        }

        public async Task<IEnumerable<NewsPost>> FindAsync(Func<NewsPost, bool> predicate)
        {
            return _db.NewsPosts.Where(predicate);
        }

        public void Create(NewsPost item)
        {
            _db.NewsPosts.Add(item);
        }

        public async Task CreateAsync(NewsPost item)
        {
            await _db.NewsPosts.AddAsync(item);
        }

        public void Update(NewsPost item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public async Task UpdateAsync(NewsPost item)
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
