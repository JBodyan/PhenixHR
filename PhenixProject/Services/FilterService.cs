using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhenixProject.Interfaces;
using PhenixProject.Models;
using Resources.Enums;

namespace PhenixProject.Services
{
    public class FilterService : IFilterService
    {
        public async Task<IEnumerable<MemberViewModel>> FilterCandidatesAsync(IEnumerable<MemberViewModel> models,
            GenderFilter gender, ArchivedFilter archived)
        {
            switch (archived)
            {
                case ArchivedFilter.All:
                    break;
                case ArchivedFilter.Archived:
                    models = models.Where(x => x.IsArchived);
                    break;
                case ArchivedFilter.UnArchived:
                    models = models.Where(x => !x.IsArchived);
                    break;
                default:
                    break;
            }
            switch (gender)
            {
                case GenderFilter.All:
                    break;
                case GenderFilter.Female:
                    models = models.Where(x => x.PersonalInfo.Gender == Gender.Female);
                    break;
                case GenderFilter.Male:
                    models = models.Where(x => x.PersonalInfo.Gender == Gender.Male);
                    break;
                default:
                    break;
            }
            return models;
        } 
    }
}
