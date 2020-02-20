using System;
using System.Collections.Generic;
using System.Text;

namespace PhenixProject.Models.Contacts
{
    public class AddressViewModel
    {
        public string Value { get; set; }
        public override string ToString()
        {
            return Value;
        }
    }
}
