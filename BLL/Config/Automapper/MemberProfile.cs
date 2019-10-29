using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Config.Automapper
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            #region Map<Member,MemberDTO>
            CreateMap<Member, MemberDTO>()
                .ForMember(
                    dest => dest.PersonalInfo,
                    opt => opt.MapFrom(src => src.PersonalInfo)
                )
                .ForMember(
                    dest => dest.IsArchived,
                    opt => opt.MapFrom(src => src.IsArchived)
                )
                .ForMember(
                    dest => dest.IsCandidate,
                    opt => opt.MapFrom(src => src.IsCandidate)
                )
                .ForMember(
                    dest => dest.IsEmployee,
                    opt => opt.MapFrom(src => src.IsEmployee)
                )
                .ForMember(
                    dest => dest.CandidateInfo,
                    opt => opt.MapFrom(src => src.CandidateInfo)
                )
                .ForMember(
                    dest => dest.EmployeeInfo,
                    opt => opt.MapFrom(src => src.EmployeeInfo)
                );
            #endregion
            #region Map<MemberDTO,Member>
            CreateMap<MemberDTO, Member>()
                .ForMember(
                    dest => dest.IsArchived,
                    opt => opt.MapFrom(src => src.IsArchived)
                )
                .ForMember(
                    dest => dest.IsCandidate,
                    opt => opt.MapFrom(src => src.IsCandidate)
                )
                .ForMember(
                    dest => dest.IsEmployee,
                    opt => opt.MapFrom(src => src.IsEmployee)
                )
                .ForMember(
                    dest => dest.CandidateInfo,
                    opt => opt.MapFrom(src => src.CandidateInfo)
                )
                .ForMember(
                    dest => dest.EmployeeInfo,
                    opt => opt.MapFrom(src => src.EmployeeInfo)
                );
            #endregion
        }
    }
}
