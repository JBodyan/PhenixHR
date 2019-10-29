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
            #region Map<MemberDTO,CandidateViewModel>

            CreateMap<MemberDTO, CandidateViewModel>()
                .ForMember(
                    dest => dest.PersonalInfo,
                    opt => opt.MapFrom(src => src.PersonalInfo)
                ).ForMember(
                    dest => dest.City,
                    opt => opt.MapFrom(src => src.CandidateInfo.City)
                ).ForMember(
                    dest => dest.CareerObjective,
                    opt => opt.MapFrom(src => src.CandidateInfo.CareerObjective)
                ).ForMember(
                    dest => dest.DesiredSalary,
                    opt => opt.MapFrom(src => src.CandidateInfo.DesiredSalary)
                ).ForMember(
                    dest => dest.About,
                    opt => opt.MapFrom(src => src.CandidateInfo.About)
                ).ForMember(
                    dest => dest.Educations,
                    opt => opt.MapFrom(src => src.CandidateInfo.Educations)
                ).ForMember(
                    dest => dest.Works,
                    opt => opt.MapFrom(src => src.CandidateInfo.Works)
                ).ForMember(
                    dest => dest.Employment,
                    opt => opt.MapFrom(src => src.CandidateInfo.Employment)
                );

            #endregion

            #region Map<CandidateViewModel,MemberDTO>

            CreateMap<CandidateViewModel, MemberDTO>()
                .ForMember(
                dest => dest.CandidateInfo,
                opt => opt.MapFrom(src => src)
            );

            #endregion


            #region Map<CandidateViewModel,CandidateDTO>

            CreateMap<CandidateViewModel, CandidateDTO>()
                .ForMember(
                    dest => dest.City,
                    opt => opt.MapFrom(src => src.City)
                ).ForMember(
                    dest => dest.CareerObjective,
                    opt => opt.MapFrom(src => src.CareerObjective)
                ).ForMember(
                    dest => dest.DesiredSalary,
                    opt => opt.MapFrom(src => src.DesiredSalary)
                ).ForMember(
                    dest => dest.About,
                    opt => opt.MapFrom(src => src.About)
                ).ForMember(
                    dest => dest.Educations,
                    opt => opt.MapFrom(src => src.Educations)
                ).ForMember(
                    dest => dest.Works,
                    opt => opt.MapFrom(src => src.Works)
                ).ForMember(
                    dest => dest.Employment,
                    opt => opt.MapFrom(src => src.Employment)
                );

            #endregion
        }
    }
}
