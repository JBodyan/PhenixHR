using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PhenixProject.Interfaces;
using PhenixProject.Models;

namespace PhenixProject.Services
{
    public class LinkService : ILinkService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public LinkService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _db = unitOfWork;
            _mapper = mapper;
        }

        public Task AddLinkAsync(Guid memberId, LinkViewModel model)
        {
            throw new NotImplementedException();
        }

        public LinkViewModel GetLinkById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<LinkViewModel> GetLinkByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinkViewModel>> GetLinksByMemberIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateLinkById(Guid id, LinkViewModel link)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLinkByIdAsync(Guid id, LinkViewModel link)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
