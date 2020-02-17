using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhenixProject.Models;

namespace PhenixProject.Interfaces
{
    public interface IHistoryService
    {
        Task AddHistoryAsync(HistoryViewModel model);
        Task<IEnumerable<HistoryViewModel>> GetHistoryByMemberIdAsync(Guid id);
        void Dispose();
    }
}
