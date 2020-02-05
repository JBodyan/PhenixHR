using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhenixProject.Models;

namespace PhenixProject.Interfaces
{
    interface INewsService
    {
        Task<NewsPostViewModel> GetNewsByIdAsync(Guid newsId);
        Task<IEnumerable<NewsPostViewModel>> GetAllNewsAsync();
        Task<IEnumerable<NewsPostViewModel>> GetNewsByDateAsync(DateTime date);
        Task AddNewsAsync(NewsPostViewModel model);
        Task UpdateNewsAsync(NewsPostViewModel model);
        Task RemoveNewsAsync(Guid id);
        void Dispose();
    }
}
