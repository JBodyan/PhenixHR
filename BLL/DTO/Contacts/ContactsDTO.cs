using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO.Contacts
{
    public class ContactsDTO
    {
        public PhoneDTO Phone { get; set; }
        public EmailDTO Email { get; set; }
        public SkypeDTO Skype { get; set; }
        public AddressDTO Address { get; set; }
    }
}
