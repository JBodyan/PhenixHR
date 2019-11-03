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
            CreateMap<Member, MemberDTO>();
            #endregion
            #region Map<MemberDTO,Member>
            CreateMap<MemberDTO, Member>();
            #endregion
        }
    }
}
