using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICandidateService
    {
        CandidateDTO GetCandidateById(Guid id);
        Task<CandidateDTO> GetCandidateByIdAsync(Guid id);
        IEnumerable<CandidateDTO> GetCandidates();
        Task<IEnumerable<CandidateDTO>> GetCandidatesAsync();
        bool AddCandidate(CandidateDTO candidate);
        bool AddCandidateAsync(CandidateDTO candidate);
        void Dispose();
    }
}
