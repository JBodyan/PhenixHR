using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models.Contacts
{
    public class ContactsViewModel
    {
        [Display(Name = "Phone")]
        public PhoneViewModel Phone { get; set; }
        [Display(Name = "SecondPhone")]
        public PhoneViewModel SecondPhone { get; set; }
        [Display(Name = "Email")]
        public EmailViewModel Email { get; set; }
        [Display(Name = "Skype")]
        public SkypeViewModel Skype { get; set; }
        [Display(Name = "Address")]
        public AddressViewModel Address { get; set; }
    }
}
