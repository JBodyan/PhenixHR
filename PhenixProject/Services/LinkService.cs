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
    public class LinkService : ILinkService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public LinkService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _db = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddLinkAsync(Guid memberId, LinkViewModel model)
        {
            var member = await _db.Members.GetByIdAsync(memberId);
            var link = _mapper.Map<Link>(model);
            link.Id = Guid.NewGuid();
            if (member.EmployeeInfo.Links == null)
            {
                member.EmployeeInfo.Links = new List<Link>
                {
                    link
                };
            }
            else
            {
                member.EmployeeInfo.Links.Add(link);
                _db.Save();
            }
        }

        public LinkViewModel GetLinkById(Guid id)
        {
            var link = _db.Links.GetById(id);
            return _mapper.Map<LinkViewModel>(link);
        }

        public async Task<LinkViewModel> GetLinkByIdAsync(Guid id)
        {
            var link = await _db.Links.GetByIdAsync(id);
            return _mapper.Map<LinkViewModel>(link);
        }

        public async Task<IEnumerable<LinkViewModel>> GetLinksByMemberIdAsync(Guid id)
        {
            var member = await _db.Members.GetByIdAsync(id);
            return _mapper.Map<IEnumerable<LinkViewModel>>(member.EmployeeInfo.Links);
        }

        public void UpdateLink(LinkViewModel link)
        {
            var model = _db.Links.GetById(link.Id);
            model.Name = link.Name;
            model.Url = link.Url;
            _db.Links.Update(model);
            _db.Save();
        }

        public async Task UpdateLinkAsync(LinkViewModel link)
        {
            var model = await _db.Links.GetByIdAsync(link.Id);
            model.Name = link.Name;
            model.Url = link.Url;
            await _db.Links.UpdateAsync(model);
            _db.Save();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task RemoveLinkAsync(Guid id)
        {
            await _db.Links.DeleteAsync(id);
            _db.Save();
        }
    }
}
