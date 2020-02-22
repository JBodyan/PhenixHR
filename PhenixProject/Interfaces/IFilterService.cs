using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhenixProject.Models;
using Resources.Enums;

namespace PhenixProject.Interfaces
{
    public interface IFilterService
    {
        Task<IEnumerable<MemberViewModel>> FilterCandidatesAsync(IEnumerable<MemberViewModel> models, GenderFilter gender,
            ArchivedFilter archived);
    }
}
