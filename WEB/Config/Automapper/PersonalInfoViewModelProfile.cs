using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using WEB.Models;

namespace WEB.Config.Automapper
{
    public class PersonalInfoViewModelProfile : Profile
    {
        public PersonalInfoViewModelProfile()
        {
            #region Map<PersonalInfoViewModel,PersonalInfoDTO>
            CreateMap<PersonalnfoViewModel, PersonalInfoDTO>()
                .ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.FirstName)
                )
                .ForMember(
                    dest => dest.MidName,
                    opt => opt.MapFrom(src => src.MidName)
                )
                .ForMember(
                    dest => dest.LastName,
                    opt => opt.MapFrom(src => src.LastName)
                )
                .ForMember(
                    dest => dest.BirthDate,
                    opt => opt.MapFrom(src => src.BirthDate)
                )
                .ForMember(
                    dest => dest.Gender,
                    opt => opt.MapFrom(src => src.Gender)
                );
            #endregion

            #region Map<PesonalInfoDTO,PersonalInfoViewModel>
            CreateMap<PersonalInfoDTO, PersonalnfoViewModel>()
                .ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.FirstName)
                )
                .ForMember(
                    dest => dest.MidName,
                    opt => opt.MapFrom(src => src.MidName)
                )
                .ForMember(
                    dest => dest.LastName,
                    opt => opt.MapFrom(src => src.LastName)
                )
                .ForMember(
                    dest => dest.BirthDate,
                    opt => opt.MapFrom(src => src.BirthDate)
                )
                .ForMember(
                    dest => dest.Gender,
                    opt => opt.MapFrom(src => src.Gender)
                );
            #endregion
        }
    }
}
