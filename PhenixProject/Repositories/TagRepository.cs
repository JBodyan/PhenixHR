using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhenixProject.Data;
using PhenixProject.Interfaces;
using PhenixProject.Models;

namespace PhenixProject.Repositories
{
    public class TagRepository : IRepository<DocumentTag>
    {
        private readonly AppIdentityDbContext _db;

        public TagRepository(AppIdentityDbContext appContext)
        {
            _db = appContext;
        }
        public IEnumerable<DocumentTag> GetAll()
        {
            return _db.DocumentTag;
        }

        public async Task<IEnumerable<DocumentTag>> GetAllAsync()
        {
            return _db.DocumentTag;
        }

        public DocumentTag GetById(Guid id)
        {
            return _db.DocumentTag.FirstOrDefault(x => x.Id == id);
        }

        public async Task<DocumentTag> GetByIdAsync(Guid id)
        {
            return await _db.DocumentTag.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<DocumentTag> Find(Func<DocumentTag, bool> predicate)
        {
            return _db.DocumentTag.Where(predicate);
        }

        public async Task<IEnumerable<DocumentTag>> FindAsync(Func<DocumentTag, bool> predicate)
        {
            return _db.DocumentTag.Where(predicate);
        }

        public void Create(DocumentTag item)
        {
            _db.DocumentTag.Add(item);
        }

        public async Task CreateAsync(DocumentTag item)
        {
            await _db.DocumentTag.AddAsync(item);
        }

        public void Update(DocumentTag item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public async Task UpdateAsync(DocumentTag item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            var tag = _db.DocumentTag.FirstOrDefault(x => x.Id == id);
            if (tag != null) _db.DocumentTag.Remove(tag);
        }

        public async Task DeleteAsync(Guid id)
        {
            var tag = await _db.DocumentTag.FirstOrDefaultAsync(x => x.Id == id);
            if (tag != null) _db.DocumentTag.Remove(tag);
        }
    }
}
