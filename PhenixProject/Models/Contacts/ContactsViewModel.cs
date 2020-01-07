using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhenixProject.Models.Contacts
{
    public class ContactsViewModel
    {
        [Required]
        public PhoneViewModel Phone { get; set; }
        public PhoneViewModel SecondPhone { get; set; }
        [Required]
        [EmailAddress]
        public EmailViewModel Email { get; set; }
        public SkypeViewModel Skype { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
