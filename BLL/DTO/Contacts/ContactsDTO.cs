using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO.Contacts
{
    public class ContactsDTO
    {
        public ICollection<PhoneDTO> Phones { get; set; }
        public ICollection<EmailDTO> Emails { get; set; }
        public ICollection<SkypeDTO> Skypes { get; set; }
        public ICollection<AddressDTO> Address { get; set; }
    }
}
