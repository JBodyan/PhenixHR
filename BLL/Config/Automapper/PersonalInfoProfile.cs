using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Config.Automapper
{
    public class PersonalInfoProfile : Profile
    {
        public PersonalInfoProfile()
        {
            #region Map<PersonalInfo,PersonalInfoDTO>
            CreateMap<PersonalInfo, PersonalInfoDTO>();
            #endregion
        }
    }
}
