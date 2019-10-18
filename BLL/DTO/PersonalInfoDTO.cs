using BLL.DTO.Contacts;
using Resources.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class PersonalInfoDTO
    {
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public virtual ContactsDTO Contacts { get; set; }
        public string Photo { get; set; }
    }
}
