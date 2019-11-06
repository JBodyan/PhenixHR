using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using WEB.Models;

namespace WEB.Config.Automapper
{
    public class EmployeeViewModelProfile : Profile
    {
        public EmployeeViewModelProfile()
        {
            #region Map<MemberDTO,CandidateViewModel>

            CreateMap<MemberDTO, EmployeeViewModel>()
                .ForMember(
                    dest => dest.PersonalInfo,
                    opt => opt.MapFrom(src => src.PersonalInfo)
                ).ForMember(
                    dest => dest.Department,
                    opt => opt.MapFrom(src => src.EmployeeInfo.Department)
                ).ForMember(
                    dest => dest.History,
                    opt => opt.MapFrom(src => src.EmployeeInfo.History)
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
                );

            #endregion

            #region Map<EmployeeViewModel,MemberDTO>

            CreateMap<EmployeeViewModel, MemberDTO>()
                .ForMember(
                    dest => dest.EmployeeInfo,
                    opt => opt.MapFrom(src => src)
                );

            #endregion

            #region Map<EmployeeViewModel,EmployeeDTO>

            CreateMap<EmployeeViewModel, EmployeeDTO>();

            #endregion

            CreateMap<OfficeViewModel, OfficeDTO>();
            CreateMap<OfficeDTO, OfficeViewModel>();

            CreateMap<DepartmentViewModel, DepartmentDTO>();
            CreateMap<DepartmentDTO, DepartmentViewModel>();

            CreateMap<PositionDTO, PositionViewModel>();
            CreateMap<PositionViewModel, PositionDTO>();

            CreateMap<PayrollDTO, PayrollViewModel>();
            CreateMap<PayrollViewModel, PayrollDTO>();

            CreateMap<LeaveViewModel, LeaveDTO>();
            CreateMap<LeaveDTO, LeaveViewModel>();
        }
    }
}
