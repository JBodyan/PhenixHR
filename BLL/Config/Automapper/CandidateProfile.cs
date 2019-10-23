using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Entities.Contacts;
using DAL.Entities.Information;

namespace BLL.Config.Automapper
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            #region Map<Member,CandidateDTO>
            CreateMap<Member, CandidateDTO>()
                .ForMember(
                    dest => dest.City,
                    opt => opt.MapFrom(src => src.CandidateInfo.City)
                )
                .ForMember(
                    dest => dest.DesiredSalary,
                    opt => opt.MapFrom(src => src.CandidateInfo.DesiredSalary)
                )
                .ForMember(
                    dest => dest.Employment,
                    opt => opt.MapFrom(src => src.CandidateInfo.Employment)
                )
                .ForMember(
                    dest => dest.Educations,
                    opt => opt.MapFrom(src => src.CandidateInfo.Educations)
                )
                .ForMember(
                    dest => dest.About,
                    opt => opt.MapFrom(src => src.CandidateInfo.About)
                )
                .ForMember(
                    dest => dest.CareerObjective,
                    opt => opt.MapFrom(src => src.CandidateInfo.CareerObjective)
                )
                .ForMember(
                    dest => dest.Works,
                    opt => opt.MapFrom(src => src.CandidateInfo.Works)
                );
            #endregion

            #region Map<CandidateDTO,Member>
            CreateMap<CandidateDTO, Member>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => Guid.NewGuid())
                )
                .ForMember(
                    dest => dest.IsCandidate,
                    opt => opt.MapFrom(src => true)
                )
                .ForMember(
                    dest => dest.CandidateInfo,
                    opt => opt.MapFrom(src => new CandidateInfo
                    {
                        Id = Guid.NewGuid(),
                        City = src.City,
                        CareerObjective = src.CareerObjective,
                        DesiredSalary = src.DesiredSalary,
                        Employment = src.Employment,
                        About = src.About
                    })
                )
                .ForMember(
                    dest => dest.PersonalInfo,
                    opt => opt.MapFrom(src => new PersonalInfo()
                    {
                        Id = Guid.NewGuid(),
                        FirstName = src.PersonalInfo.FirstName,
                        MidName = src.PersonalInfo.MidName,
                        LastName = src.PersonalInfo.LastName,
                        Gender = src.PersonalInfo.Gender,
                        BirthDate = src.PersonalInfo.BirthDate,
                        Contacts = new MemberContacts()
                        {
                            Id = Guid.NewGuid()
                        }
                    })
                );
            #endregion

        }
    }
}
