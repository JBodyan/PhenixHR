using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PhenixProject.Entities;
using PhenixProject.Interfaces;
using PhenixProject.Models;

namespace PhenixProject.Services
{
    public class NewsService : INewsService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public NewsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _db = unitOfWork;
            _mapper = mapper;
        }
        public async Task<NewsPostViewModel> GetNewsByIdAsync(Guid newsId)
        {
            var news = await _db.NewsPosts.GetByIdAsync(newsId);
            return _mapper.Map<NewsPostViewModel>(news);
        }

        public async Task<IEnumerable<NewsPostViewModel>> GetAllNewsAsync()
        {
            var news = await _db.NewsPosts.GetAllAsync();
            return _mapper.Map<IEnumerable<NewsPostViewModel>>(news);
        }

        public async Task<IEnumerable<NewsPostViewModel>> GetNewsByDateAsync(DateTime date)
        {
            var news = await _db.NewsPosts.FindAsync(x=>x.PostedTime == date);
            return _mapper.Map<IEnumerable<NewsPostViewModel>>(news);
        }

        public async Task AddNewsAsync(NewsPostViewModel model)
        {
            var news = _mapper.Map<NewsPost>(model);
            await _db.NewsPosts.CreateAsync(news);
            _db.Save();
        }

        public async Task UpdateNewsAsync(NewsPostViewModel model)
        {
            var news = await _db.NewsPosts.GetByIdAsync(model.Id);
            if (news != null)
            {
                news.Description = model.Description;
                news.Title = model.Title;
                news.EditedTime = DateTime.Now;
            }
            await _db.NewsPosts.UpdateAsync(news);
            _db.Save();
        }

        public async Task RemoveNewsAsync(Guid id)
        {
            await _db.NewsPosts.DeleteAsync(id);
            _db.Save();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
