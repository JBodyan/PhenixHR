using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.ExceptionStructure;
using BLL.Interfaces;
using DAL.Repositories.Interfaces;

namespace BLL.Services
{
    public class PersonalInfoService : IPersonalInfoService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public PersonalInfoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _db = unitOfWork;
            _mapper = mapper;
        }

        public PersonalInfoDTO GetPersonalInfoByMemberId(Guid id)
        {
            if (id == null) throw new CustomValidationException("Id не указан", "");

            var member = _db.Members.GetById(id);
            if (member == null) throw new CustomValidationException("Сотрудник не найден", "");

            var data = _mapper.Map<PersonalInfoDTO>(member.PersonalInfo);
            return data;
        }

        public async Task<PersonalInfoDTO> GetPersonalInfoByMemberIdAsync(Guid id)
        {
            if (id == null) throw new CustomValidationException("Id не указан", "");

            var member = await _db.Members.GetByIdAsync(id);
            if (member == null) throw new CustomValidationException("Сотрудник не найден", "");

            var data = _mapper.Map<PersonalInfoDTO>(member.PersonalInfo);
            return data;
        }

        public void UpdatePersonalInfoByMemberId(Guid id, PersonalInfoDTO personalInfo)
        {
            if (id == null) throw new CustomValidationException("Id не указан", "");

            var member = _db.Members.GetById(id);
            if (member == null) throw new CustomValidationException("Сотрудник не найден", "");

            member.PersonalInfo.FirstName = personalInfo.FirstName;
            member.PersonalInfo.MidName = personalInfo.MidName;
            member.PersonalInfo.LastName = personalInfo.LastName;
            member.PersonalInfo.BirthDate = personalInfo.BirthDate;
            member.PersonalInfo.Gender = personalInfo.Gender;

        }

        public async Task UpdatePersonalInfoByMemberIdAsync(Guid id, PersonalInfoDTO personalInfo)
        {
            if (id == null) throw new CustomValidationException("Id не указан", "");

            var member = await _db.Members.GetByIdAsync(id);
            if (member == null) throw new CustomValidationException("Сотрудник не найден", "");

            member.PersonalInfo.FirstName = personalInfo.FirstName;
            member.PersonalInfo.MidName = personalInfo.MidName;
            member.PersonalInfo.LastName = personalInfo.LastName;
            member.PersonalInfo.BirthDate = personalInfo.BirthDate;
            member.PersonalInfo.Gender = personalInfo.Gender;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
