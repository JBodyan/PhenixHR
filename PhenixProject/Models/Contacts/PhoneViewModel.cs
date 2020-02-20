using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhenixProject.Models.Contacts
{
    public class PhoneViewModel
    {
        public string Value { get; set; }
        public override string ToString()
        {
            return Value;
        }
    }

}
