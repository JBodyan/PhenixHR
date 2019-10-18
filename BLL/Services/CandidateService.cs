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

namespace BLL.Services
{
    public class CandidateService : ICandidateService
    {
        private IUnitOfWork Db { get; set; }
        public CandidateService(IUnitOfWork unitOfWork)
        {
            Db = unitOfWork;
        }

        #region SyncMethods
        public bool AddCandidate(CandidateDTO candidate)
        {
            if (candidate == null) throw new CustomValidationException("Кандидат не передан", "");

            //var mapper = AutoMapperConfig.CandidateDTOToMemberMapper;
            try
            {
                //Db.Members.Create(mapper.Map<CandidateDTO, Member>(candidate));
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

            var candidate = Db.Members.GetById(id);
            if (candidate == null)
                throw new CustomValidationException("Кандидат не найден", "");

            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Member, CandidateDTO>();
                cfg.CreateMap<CandidateInfo, CandidateDTO>();
                cfg.CreateMap<PersonalInfoDTO, PersonalInfo>();
                cfg.CreateMap<PhoneDTO, Phone>();
                cfg.CreateMap<EmailDTO, Email>();
                cfg.CreateMap<SkypeDTO, Skype>();
                cfg.CreateMap<AddressDTO, Address>();
                cfg.CreateMap<EducationDTO, EducationInfo>();
                cfg.CreateMap<WorkDTO, WorkInfo>();
                cfg.CreateMap<ContactsDTO, MemberContacts>();
            }).CreateMapper();
            if (candidate.IsCandidate)
                return mapper.Map<Member, CandidateDTO>(candidate);
            else throw new CustomValidationException("Пользователь не является кандидатом", "");

        }

        public IEnumerable<CandidateDTO> GetCandidates()
        {
            List<Member> candidates = Db.Members.Find(m => m.IsCandidate).ToList();
            if (candidates == null || candidates.Count < 1)
                throw new CustomValidationException("Кандидатов нет", "");
            else
            {
                var mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Member, CandidateDTO>();
                    cfg.CreateMap<CandidateInfo, CandidateDTO>();
                    cfg.CreateMap<PersonalInfoDTO, PersonalInfo>();
                    cfg.CreateMap<PhoneDTO, Phone>();
                    cfg.CreateMap<EmailDTO, Email>();
                    cfg.CreateMap<SkypeDTO, Skype>();
                    cfg.CreateMap<AddressDTO, Address>();
                    cfg.CreateMap<EducationDTO, EducationInfo>();
                    cfg.CreateMap<WorkDTO, WorkInfo>();
                    cfg.CreateMap<ContactsDTO, MemberContacts>();
                }).CreateMapper();
                var data = mapper.Map<IEnumerable<Member>, IEnumerable<CandidateDTO>>(candidates);
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
            Db.Dispose();
        }
    }
}
