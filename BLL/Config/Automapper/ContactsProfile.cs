using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLL.DTO.Contacts;
using DAL.Entities.Contacts;

namespace BLL.Config.Automapper
{
    public class ContactsProfile : Profile
    {
        public ContactsProfile()
        {
            CreateMap<ContactsDTO, MemberContacts>();
            CreateMap<MemberContacts, ContactsDTO>();

            CreateMap<PhoneDTO, Phone>();
            CreateMap<EmailDTO, Email>();
            CreateMap<SkypeDTO, Skype>();
            CreateMap<AddressDTO, Address>();

            CreateMap<Phone, PhoneDTO>();
            CreateMap<Email, EmailDTO>();
            CreateMap<Skype, SkypeDTO>();
            CreateMap<Address, AddressDTO>();
        }
    }
}
