using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhenixProject.Models;

namespace PhenixProject.Interfaces
{
    interface ILinkService
    {
        Task AddLinkAsync(Guid memberId, LinkViewModel model);
        LinkViewModel GetLinkById(Guid id);
        Task<LinkViewModel> GetLinkByIdAsync(Guid id);
        Task<IEnumerable<LinkViewModel>> GetLinksByMemberIdAsync(Guid id);
        void UpdateLinkById(Guid id, LinkViewModel link);
        Task UpdateLinkByIdAsync(Guid id, LinkViewModel link);
        void Dispose();
    }
}
