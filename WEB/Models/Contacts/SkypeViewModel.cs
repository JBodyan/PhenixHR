using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models.Contacts
{
    public class SkypeViewModel
    {
        [StringLength(30,ErrorMessage = "Max lenght {1}")]
        public string Value { get; set; }
    }
}
