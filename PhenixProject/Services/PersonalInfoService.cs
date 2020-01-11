using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PhenixProject.Interfaces;
using PhenixProject.Models;

namespace PhenixProject.Services
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

        public PersonalInfoViewModel GetPersonalInfoByMemberId(Guid id)
        {
            if (id == null) throw new Exception("Id не указан");

            var member = _db.Members.GetById(id);
            if (member == null) throw new Exception("Сотрудник не найден");

            var data = _mapper.Map<PersonalInfoViewModel>(member.PersonalInfo);
            return data;
        }

        public async Task<PersonalInfoViewModel> GetPersonalInfoByMemberIdAsync(Guid id)
        {
            if (id == null) throw new Exception("Id не указан");

            var member = await _db.Members.GetByIdAsync(id);
            if (member == null) throw new Exception("Member not found");

            var data = _mapper.Map<PersonalInfoViewModel>(member.PersonalInfo);
            return data;
        }

        public void UpdatePersonalInfoByMemberId(Guid id, PersonalInfoViewModel personalInfo)
        {
            if (id == null) throw new Exception("Id не указан");

            var member = _db.Members.GetById(id);
            if (member == null) throw new Exception("Member not found");

            member.PersonalInfo.FirstName = personalInfo.FirstName;
            member.PersonalInfo.MidName = personalInfo.MidName;
            member.PersonalInfo.LastName = personalInfo.LastName;
            member.PersonalInfo.BirthDate = personalInfo.BirthDate;
            member.PersonalInfo.Gender = personalInfo.Gender;
            member.PersonalInfo.Contacts.Email.Value = personalInfo.Contacts.Email.Value;
            member.PersonalInfo.Contacts.Phone.Value = personalInfo.Contacts.Phone.Value;
            member.PersonalInfo.Contacts.SecondPhone.Value = personalInfo.Contacts.SecondPhone.Value;
            member.PersonalInfo.Contacts.Skype.Value = personalInfo.Contacts.Skype.Value;
            member.PersonalInfo.Contacts.Address.Value = personalInfo.Contacts.Address.Value;
            _db.Members.Update(member);
            _db.Save();

        }

        public async Task UpdatePersonalInfoByMemberIdAsync(Guid id, PersonalInfoViewModel personalInfo)
        {
            if (id == null) throw new Exception("Id не указан");

            var member = await _db.Members.GetByIdAsync(id);
            if (member == null) throw new Exception("Member not found");

            member.PersonalInfo.FirstName = personalInfo.FirstName;
            member.PersonalInfo.MidName = personalInfo.MidName;
            member.PersonalInfo.LastName = personalInfo.LastName;
            member.PersonalInfo.BirthDate = personalInfo.BirthDate;
            member.PersonalInfo.Gender = personalInfo.Gender;
            member.PersonalInfo.Contacts.Email.Value = personalInfo.Contacts.Email.Value;
            member.PersonalInfo.Contacts.Phone.Value = personalInfo.Contacts.Phone.Value;
            member.PersonalInfo.Contacts.SecondPhone.Value = personalInfo.Contacts.SecondPhone.Value;
            member.PersonalInfo.Contacts.Skype.Value = personalInfo.Contacts.Skype.Value;
            member.PersonalInfo.Contacts.Address.Value = personalInfo.Contacts.Address.Value;
            await _db.Members.UpdateAsync(member);
            _db.Save();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
