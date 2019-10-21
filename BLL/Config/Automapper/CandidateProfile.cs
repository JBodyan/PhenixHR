using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Config.Automapper
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            CreateMap<Member,CandidateDTO>();
        }
    }
}
