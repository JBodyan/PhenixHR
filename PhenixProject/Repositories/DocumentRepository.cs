using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhenixProject.Data;
using PhenixProject.Interfaces;

namespace PhenixProject.Repositories
{
    public class DocumentRepository : IRepository<Document>
    {
        private readonly AppIdentityDbContext _db;

        public DocumentRepository(AppIdentityDbContext appContext)
        {
            _db = appContext;
        }

        public IEnumerable<Document> GetAll()
        {
            return _db.Documents;
        }

        public async Task<IEnumerable<Document>> GetAllAsync()
        {
            return _db.Documents;
        }

        public Document GetById(Guid id)
        {
            return _db.Documents.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Document> GetByIdAsync(Guid id)
        {
            return await _db.Documents.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<Document> Find(Func<Document, bool> predicate)
        {
            return _db.Documents.Where(predicate);
        }

        public async Task<IEnumerable<Document>> FindAsync(Func<Document, bool> predicate)
        {
            return _db.Documents.Where(predicate);
        }

        public void Create(Document item)
        {
            _db.Documents.Add(item);
        }

        public async Task CreateAsync(Document item)
        {
            await _db.Documents.AddAsync(item);
        }

        public void Update(Document item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public async Task UpdateAsync(Document item)
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
