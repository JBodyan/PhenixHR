using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.DTO.Contacts;
using WEB.Models;
using WEB.Models.Contacts;

namespace WEB.Config.Automapper
{
    public class CandidateViewModelProfile : Profile
    {
        public CandidateViewModelProfile()
        {
            #region Map<CandidateDTO,CandidateViewModel>
            CreateMap<CandidateDTO, CandidateViewModel>()
                .ForMember(
                    dest => dest.City,
                    opt => opt.MapFrom(src => src.City)
                )
                .ForMember(
                    dest => dest.DesiredSalary,
                    opt => opt.MapFrom(src => src.DesiredSalary)
                )
                .ForMember(
                    dest => dest.Employment,
                    opt => opt.MapFrom(src => src.Employment)
                )
                .ForMember(
                    dest => dest.Educations,
                    opt => opt.MapFrom(src => src.Educations)
                )
                .ForMember(
                    dest => dest.About,
                    opt => opt.MapFrom(src => src.About)
                )
                .ForMember(
                    dest => dest.CareerObjective,
                    opt => opt.MapFrom(src => src.CareerObjective)
                )
                .ForMember(
                    dest => dest.Works,
                    opt => opt.MapFrom(src => src.Works)
                ).ForMember(
                    dest => dest.PersonalInfo,
                    opt => opt.MapFrom(src => src.PersonalInfo)
                );
            #endregion

            #region Map<CandidateViewModel,CandidateDTO>
            CreateMap<CandidateViewModel, CandidateDTO>()
                .ForMember(
                    dest => dest.City,
                    opt => opt.MapFrom(src => src.City)
                )
                .ForMember(
                    dest => dest.DesiredSalary,
                    opt => opt.MapFrom(src => src.DesiredSalary)
                )
                .ForMember(
                    dest => dest.Employment,
                    opt => opt.MapFrom(src => src.Employment)
                )
                .ForMember(
                    dest => dest.Educations,
                    opt => opt.MapFrom(src => src.Educations)
                )
                .ForMember(
                    dest => dest.About,
                    opt => opt.MapFrom(src => src.About)
                )
                .ForMember(
                    dest => dest.CareerObjective,
                    opt => opt.MapFrom(src => src.CareerObjective)
                )
                .ForMember(
                    dest => dest.Works,
                    opt => opt.MapFrom(src => src.Works)
                ).ForMember(
                    dest => dest.PersonalInfo,
                    opt => opt.MapFrom(src => src.PersonalInfo)
                );
            #endregion

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
