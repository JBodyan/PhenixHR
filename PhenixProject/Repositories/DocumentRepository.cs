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
            var documents = _db.Documents;
            foreach (var document in documents)
            {
                _db.Entry(document).Collection(x => x.Tags).Load();
            }
            return documents;
        }

        public async Task<IEnumerable<Document>> GetAllAsync()
        {
            var documents = _db.Documents;
            foreach (var document in documents)
            {
                await _db.Entry(document).Collection(x => x.Tags).LoadAsync();
            }
            return documents;
        }

        public Document GetById(Guid id)
        {
            var document = _db.Documents.FirstOrDefault(x => x.Id == id);
            if (document == null) return null;
            _db.Entry(document).Collection(x => x.Tags).Load();
            return document;

        }

        public async Task<Document> GetByIdAsync(Guid id)
        {
            var document = await _db.Documents.FirstOrDefaultAsync(x => x.Id == id);
            if (document == null) return null;
            await _db.Entry(document).Collection(x => x.Tags).LoadAsync();
            return document;
        }

        public IEnumerable<Document> Find(Func<Document, bool> predicate)
        {
            return _db.Documents.Where(predicate);
        }

        public async Task<IEnumerable<Document>> FindAsync(Func<Document, bool> predicate)
        {
            var documents = _db.Documents.Where(predicate);
            foreach (var document in documents)
            {
                await _db.Entry(document).Collection(x => x.Tags).LoadAsync();
            }
            return documents;
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

        public async Task DeleteAsync(Guid id)
        {
            var document = await _db.Documents.FirstOrDefaultAsync(x => x.Id == id);
            if (document != null)
            {
                document.IsArchived = true;
            }
        }
    }
}
