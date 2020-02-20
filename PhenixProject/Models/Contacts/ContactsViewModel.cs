using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Text;

namespace PhenixProject.Models.Contacts
{
    public class ContactsViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public PhoneViewModel Phone { get; set; }
        public PhoneViewModel SecondPhone { get; set; }
        [Required]
        [EmailAddress]
        public EmailViewModel Email { get; set; }
        public SkypeViewModel Skype { get; set; }
        public AddressViewModel Address { get; set; }
        public override string ToString()
        {
            return string.Join(" ", Phone, SecondPhone, Email, Skype, Address);
        }
    }
}
