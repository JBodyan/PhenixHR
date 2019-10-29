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
            CreateMap<ContactsDTO, MemberContacts>()
                .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => src.Email)
                ).ForMember(
                dest => dest.Phone,
                opt => opt.MapFrom(src => src.Phone)
                ).ForMember(
                dest => dest.SecondPhone,
                opt => opt.MapFrom(src => src.SecondPhone)
                ).ForMember(
                dest => dest.Address,
                opt => opt.MapFrom(src => src.Address)
                ).ForMember(
                dest => dest.Skype,
                opt => opt.MapFrom(src => src.Skype)
                );
            CreateMap<MemberContacts, ContactsDTO>()
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => src.Email)
                ).ForMember(
                    dest => dest.Phone,
                    opt => opt.MapFrom(src => src.Phone)
                ).ForMember(
                    dest => dest.SecondPhone,
                    opt => opt.MapFrom(src => src.SecondPhone)
                ).ForMember(
                    dest => dest.Address,
                    opt => opt.MapFrom(src => src.Address)
                ).ForMember(
                    dest => dest.Skype,
                    opt => opt.MapFrom(src => src.Skype)
                );

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
