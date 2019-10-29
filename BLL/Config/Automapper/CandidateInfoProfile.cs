using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Config.Automapper
{
    public class CandidateInfoProfile : Profile
    {
        public CandidateInfoProfile()
        {
            #region Map<CandidateInfo,CandidateDTO>
            CreateMap<CandidateInfo, CandidateDTO>();
            #endregion
            #region Map<CandidateDTO,CandidateInfo>
            CreateMap<CandidateDTO, CandidateInfo>();
            #endregion
        }
    }
}
