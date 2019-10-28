using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO.Contacts;
using WEB.Models.Contacts;

namespace WEB.Config.Automapper
{
    public class ContactsViewModelProfile : Profile
    {
        public ContactsViewModelProfile()
        {
            CreateMap<ContactsDTO, ContactsViewModel>();
            CreateMap<ContactsViewModel, ContactsDTO>();

            CreateMap<PhoneDTO, PhoneViewModel>();
            CreateMap<EmailDTO, EmailViewModel>();
            CreateMap<SkypeDTO, SkypeViewModel>();
            CreateMap<AddressDTO, AddressViewModel>();

            CreateMap<PhoneViewModel, PhoneDTO>();
            CreateMap<EmailViewModel, EmailDTO>();
            CreateMap<SkypeViewModel, SkypeDTO>();
            CreateMap<AddressViewModel, AddressDTO>();
        }
    }
}
