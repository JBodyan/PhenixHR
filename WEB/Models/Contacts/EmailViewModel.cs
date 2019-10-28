using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models.Contacts
{
    public class EmailViewModel
    {
        [Required(ErrorMessage = "Please enter email address")]
        [EmailAddress(ErrorMessage = "Not valid email address")]
        [Display(Name = "Email")]
        public string Value { get; set; }
    }
}
