using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhenixProject.Models;

namespace PhenixProject.Interfaces
{
    public interface IDocumentService
    {
        Task AddDocumentAsync(DocumentViewModel model);
        DocumentViewModel GetDocumentById(Guid id);
        Task<DocumentViewModel> GetDocumentByIdAsync(Guid id);
        Task<IEnumerable<DocumentViewModel>> GetDocumentsAsync();
        Task<IEnumerable<DocumentViewModel>> GetDocumentsByUserIdAsync(string id);
        void UpdateDocument(DocumentViewModel model);
        Task UpdateDocumentAsync(DocumentViewModel model);
        Task AddTagAsync(Guid documentId, DocumentTagViewModel model);
        Task RemoveTagAsync(Guid documentId, DocumentTagViewModel model);
        Task RemoveDocumentAsync(Guid id);
        void Dispose();
    }
}

