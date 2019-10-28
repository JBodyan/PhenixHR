using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models.Contacts
{
    public class AddressViewModel
    {
        [StringLength(150,ErrorMessage = "Max length {1}")]
        [Display(Name = "Address")]
        public string Value { get; set; }
    }
}
