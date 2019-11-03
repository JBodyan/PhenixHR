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
            CreateMap<PersonalnfoViewModel, PersonalInfoDTO>();
            #endregion

            #region Map<PesonalInfoDTO,PersonalInfoViewModel>
            CreateMap<PersonalInfoDTO, PersonalnfoViewModel>();
            #endregion
        }
    }
}
