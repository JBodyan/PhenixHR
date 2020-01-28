using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PhenixProject.Data;
using PhenixProject.Entities;
using PhenixProject.Interfaces;
using PhenixProject.Models;

namespace PhenixProject.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public DocumentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _db = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddDocumentAsync(DocumentViewModel model)
        {
            var document = _mapper.Map<Document>(model);
            document.Tags = new List<DocumentTag>();
            await _db.Documents.CreateAsync(document);
            _db.Save();
        }

        public DocumentViewModel GetDocumentById(Guid id)
        {
            var document = _db.Documents.GetById(id);
            return document != null ? _mapper.Map<DocumentViewModel>(document) : null;
        }

        public async Task<DocumentViewModel> GetDocumentByIdAsync(Guid id)
        {
            var document = await _db.Documents.GetByIdAsync(id);
            return document != null ? _mapper.Map<DocumentViewModel>(document) : null;
        }

        public async Task<IEnumerable<DocumentViewModel>> GetDocumentsByUserIdAsync(string id)
        {
            var documents = await _db.Documents.FindAsync(x => x.UserId == id);
            return documents != null ? _mapper.Map<IEnumerable<DocumentViewModel>>(documents) : null;
        }

        public Task UpdateTagAsync(DocumentTagViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveTagAsync(Guid documentId, DocumentTagViewModel model)
        {
            var document = await _db.Documents.GetByIdAsync(documentId);
            var tag = _mapper.Map<DocumentTag>(model);
            (document.Tags as List<DocumentTag>)?.Remove(tag);
            _db.Save();
        }

        public async Task RemoveDocumentAsync(Guid id)
        {
            await _db.Documents.DeleteAsync(id);
        }

        public void UpdateDocument(DocumentViewModel model)
        {
            var document = _db.Documents.GetById(model.Id);
            document.Description = model.Description;
            document.Name = model.Name;
            document.Path = model.Path;
            document.OriginalName = model.OriginalName;
            _db.Documents.Update(document);
            _db.Save();
        }

        public async Task UpdateDocumentAsync(DocumentViewModel model)
        {
            var document = _db.Documents.GetById(model.Id);
            document.Description = model.Description;
            document.Name = model.Name;
            document.OriginalName = model.OriginalName;
            document.Path = model.Path;
            await _db.Documents.UpdateAsync(document);
            _db.Save();
        }

        public async Task AddTagAsync(Guid documentId, DocumentTagViewModel model)
        {
            var document = await _db.Documents.GetByIdAsync(documentId);
            var tag = _mapper.Map<DocumentTag>(model);
            tag.Id = Guid.NewGuid();
            document.Tags?.Add(tag);
            await _db.Documents.UpdateAsync(document);
            _db.Save();
        }

        public async Task<DocumentTagViewModel> GetTagByIdAsync(Guid id)
        {
            var tag = await _db.Tags.GetByIdAsync(id);
            return _mapper.Map<DocumentTagViewModel>(tag);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task<IEnumerable<DocumentViewModel>> GetDocumentsAsync()
        {
            var documents = await _db.Documents.GetAllAsync();
            return documents != null ? _mapper.Map<IEnumerable<DocumentViewModel>>(documents) : null;
        }
    }
}
