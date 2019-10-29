using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Config.Automapper
{
    public class EmployeeInfoProfile : Profile
    {
        public EmployeeInfoProfile()
        {
            #region Map<EmployeeInfo,EmployeeDTO>
            CreateMap<EmployeeInfo, EmployeeDTO>();
            #endregion
            #region Map<EmployeeDTO,EmployeeInfo>
            CreateMap<EmployeeDTO, EmployeeInfo>();
            #endregion
        }
    }
}
