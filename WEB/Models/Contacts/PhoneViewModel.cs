using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models.Contacts
{
    public class PhoneViewModel
    {
        [Phone(ErrorMessage = "Please enter valid phone number")]
        public string Value { get; set; }
    }
}
