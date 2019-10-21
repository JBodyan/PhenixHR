using AutoMapper;
using BLL.DTO;
using BLL.DTO.Contacts;
using BLL.DTO.Information;
using BLL.ExceptionStructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Entities.Contacts;
using DAL.Entities.Information;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public CandidateService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _db = unitOfWork;
            _mapper = mapper;
        }

        #region SyncMethods
        public bool AddCandidate(CandidateDTO candidate)
        {
            if (candidate == null) throw new CustomValidationException("Кандидат не передан", "");

            //var mapper = AutoMapperConfig.CandidateDTOToMemberMapper;
            try
            {
                //_db.Members.Create(mapper.Map<CandidateDTO, Member>(candidate));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CandidateDTO GetCandidateById(Guid id)
        {
            if (id == null) throw new CustomValidationException("Id не указан", "");

            var candidate = _db.Members.GetById(id);
            if (candidate == null)
                throw new CustomValidationException("Кандидат не найден", "");

            if (candidate.IsCandidate)
                return _mapper.Map<CandidateDTO>(candidate);
            else throw new CustomValidationException("Пользователь не является кандидатом", "");

        }

        public IEnumerable<CandidateDTO> GetCandidates()
        {
            var candidates = _db.Members.Find(m => m.IsCandidate).ToList();
            if (candidates == null || candidates.Count < 1)
                throw new CustomValidationException("Кандидатов нет", "");
            else
            {
                var data = _mapper.Map<IEnumerable<CandidateDTO>>(candidates);
                return data;
            }
        }
        #endregion

        #region AsyncMethods
        public Task<CandidateDTO> GetCandidateByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CandidateDTO>> GetCandidatesAsync()
        {
            throw new NotImplementedException();
        }

        public bool AddCandidateAsync(CandidateDTO candidate)
        {
            throw new NotImplementedException();
        }
        #endregion

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
