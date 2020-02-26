using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PhenixProject.Data;
using PhenixProject.Entities;
using PhenixProject.Entities.Contacts;
using PhenixProject.Models;
using PhenixProject.Models.Contacts;

namespace PhenixProject.Configuration
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile()
        {
            #region Contacts

            CreateMap<MemberContacts, ContactsViewModel>();
            CreateMap<ContactsViewModel, MemberContacts>();

            CreateMap<Phone, PhoneViewModel>();
            CreateMap<Email, EmailViewModel>();
            CreateMap<Skype, SkypeViewModel>();
            CreateMap<Address, AddressViewModel>();

            CreateMap<PhoneViewModel, Phone>();
            CreateMap<EmailViewModel, Email>();
            CreateMap<SkypeViewModel, Skype>();
            CreateMap<AddressViewModel, Address>();

            #endregion

            CreateMap<Office, OfficeViewModel>();
            CreateMap<OfficeViewModel, Office>();

            CreateMap<Department, DepartmentViewModel>();
            CreateMap<DepartmentViewModel, Department>();

            CreateMap<Position, PositionViewModel>();
            CreateMap<PositionViewModel, Position>();

            CreateMap<PersonalInfo, PersonalInfoViewModel>();
            CreateMap<PersonalInfoViewModel, PersonalInfo>();

            CreateMap<Payroll, PayrollViewModel>();
            CreateMap<PayrollViewModel, Payroll>();

            CreateMap<LeaveViewModel, Leave>();
            CreateMap<Leave, LeaveViewModel>();

            CreateMap<Link, LinkViewModel>();
            CreateMap<LinkViewModel, Link>();

            CreateMap<Skill, SkillViewModel>();
            CreateMap<SkillViewModel, Skill>();

            CreateMap<CandidateInfo, CandidateViewModel>();
            CreateMap<CandidateViewModel, CandidateInfo>();

            CreateMap<EmployeeInfo, EmployeeViewModel>();
            CreateMap<EmployeeViewModel, EmployeeInfo>();

            CreateMap<Member, MemberViewModel>()
                .ForMember(
                dest => dest.CandidateInfo,
                opt => opt.MapFrom(src => src.CandidateInfo)
                ).ForMember(
                dest => dest.EmployeeInfo,
                opt => opt.MapFrom(src => src.EmployeeInfo)
                ).ForMember(
                dest => dest.PersonalInfo,
                opt => opt.MapFrom(src => src.PersonalInfo)
            );

            CreateMap<MemberViewModel, Member>()
                .ForMember(
                    dest => dest.CandidateInfo,
                    opt => opt.MapFrom(src => src.CandidateInfo)
                ).ForMember(
                    dest => dest.EmployeeInfo,
                    opt => opt.MapFrom(src => src.EmployeeInfo)
                ).ForMember(
                    dest => dest.PersonalInfo,
                    opt => opt.MapFrom(src => src.PersonalInfo)
                );

            #region Member

            CreateMap<Member, CandidateViewModel>()
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
                ).ForMember(
                    dest => dest.IsArchived,
                    opt => opt.MapFrom(src => src.IsArchived)
                );

            CreateMap<CandidateViewModel, Member>()
                .ForMember(
                    dest => dest.CandidateInfo,
                    opt => opt.MapFrom(src => src)
                );

            CreateMap<EmployeeViewModel, Member>()
                .ForMember(
                    dest => dest.EmployeeInfo,
                    opt => opt.MapFrom(src => src)
                );

            CreateMap<Member, EmployeeViewModel>()
                .ForMember(
                    dest => dest.PersonalInfo,
                    opt => opt.MapFrom(src => src.PersonalInfo)
                ).ForMember(
                    dest => dest.Department,
                    opt => opt.MapFrom(src => src.EmployeeInfo.Department)
                ).ForMember(
                    dest => dest.Histories,
                    opt => opt.MapFrom(src => src.EmployeeInfo.Histories)
                ).ForMember(
                    dest => dest.Leaves,
                    opt => opt.MapFrom(src => src.EmployeeInfo.Leaves)
                ).ForMember(
                    dest => dest.Office,
                    opt => opt.MapFrom(src => src.EmployeeInfo.Office)
                ).ForMember(
                    dest => dest.Position,
                    opt => opt.MapFrom(src => src.EmployeeInfo.Position)
                ).ForMember(
                    dest => dest.Payroll,
                    opt => opt.MapFrom(src => src.EmployeeInfo.Payroll)
                ).ForMember(
                    dest => dest.Links,
                    opt => opt.MapFrom(src => src.EmployeeInfo.Links)
                ).ForMember(
                    dest => dest.Skills,
                    opt => opt.MapFrom(src => src.EmployeeInfo.Skills)
                );

            #endregion

            #region MemberViewModel

            CreateMap<MemberViewModel, CandidateViewModel>()
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
                ).ForMember(
                    dest => dest.IsArchived,
                    opt => opt.MapFrom(src => src.IsArchived)
                ).ForMember(
                    dest => dest.PathCV,
                    opt => opt.MapFrom(src => src.CandidateInfo.PathCV)
                ).ForMember(
                    dest => dest.Currency,
                    opt => opt.MapFrom(src => src.CandidateInfo.Currency)
                );

            CreateMap<CandidateViewModel, MemberViewModel>()
                .ForMember(
                    dest => dest.CandidateInfo,
                    opt => opt.MapFrom(src => src)
                );

            CreateMap<EmployeeViewModel, MemberViewModel>()
                .ForMember(
                    dest => dest.EmployeeInfo,
                    opt => opt.MapFrom(src => src)
                );

            CreateMap<MemberViewModel, EmployeeViewModel>()
                .ForMember(
                    dest => dest.PersonalInfo,
                    opt => opt.MapFrom(src => src.PersonalInfo)
                ).ForMember(
                    dest => dest.Department,
                    opt => opt.MapFrom(src => src.EmployeeInfo.Department)
                ).ForMember(
                    dest => dest.Histories,
                    opt => opt.MapFrom(src => src.EmployeeInfo.Histories)
                ).ForMember(
                    dest => dest.Leaves,
                    opt => opt.MapFrom(src => src.EmployeeInfo.Leaves)
                ).ForMember(
                    dest => dest.Office,
                    opt => opt.MapFrom(src => src.EmployeeInfo.Office)
                ).ForMember(
                    dest => dest.Position,
                    opt => opt.MapFrom(src => src.EmployeeInfo.Position)
                ).ForMember(
                    dest => dest.Payroll,
                    opt => opt.MapFrom(src => src.EmployeeInfo.Payroll)
                ).ForMember(
                    dest => dest.Links,
                    opt => opt.MapFrom(src => src.EmployeeInfo.Links)
                ).ForMember(
                    dest => dest.Skills,
                    opt => opt.MapFrom(src => src.EmployeeInfo.Skills)
                );

            #endregion

            CreateMap<EmployeeViewModel, EmployeeInfo>();

            CreateMap<DocumentTagViewModel, DocumentTag>();
            CreateMap<DocumentTag, DocumentTagViewModel>();

            CreateMap<DocumentViewModel, Document>();
            CreateMap<Document, DocumentViewModel>();

            CreateMap<NewsPost, NewsPostViewModel>();
            CreateMap<NewsPostViewModel, NewsPost>();

            CreateMap<HistoryViewModel, EmployeeHistory>();
            CreateMap<EmployeeHistory, HistoryViewModel>();

        }
    }
}
