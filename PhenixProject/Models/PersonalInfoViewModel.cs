using PhenixProject.Models.Contacts;
using Resources.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhenixProject.Models
{
    public class PersonalInfoViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MidName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public virtual ContactsViewModel Contacts { get; set; }
        public string Photo { get; set; }
    }
}
