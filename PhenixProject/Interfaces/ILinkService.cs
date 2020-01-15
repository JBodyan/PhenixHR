using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhenixProject.Models;

namespace PhenixProject.Interfaces
{
    public interface ILinkService
    {
        Task AddLinkAsync(Guid memberId, LinkViewModel model);
        LinkViewModel GetLinkById(Guid id);
        Task<LinkViewModel> GetLinkByIdAsync(Guid id);
        Task<IEnumerable<LinkViewModel>> GetLinksByMemberIdAsync(Guid id);
        void UpdateLink(LinkViewModel link);
        Task UpdateLinkAsync(LinkViewModel link);
        Task RemoveLinkAsync(Guid id);
        void Dispose();
    }
}
