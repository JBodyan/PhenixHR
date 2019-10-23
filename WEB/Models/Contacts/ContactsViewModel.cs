using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models.Contacts
{
    public class ContactsViewModel
    {
        public ICollection<PhoneViewModel> Phones { get; set; }
        public ICollection<EmailViewModel> Emails { get; set; }
        public ICollection<SkypeViewModel> Skypes { get; set; }
        public ICollection<AddressViewModel> Address { get; set; }
    }
}
