using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities.Contacts
{
    public class MemberContacts
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public ICollection<Phone> Phones { get; set; }
        public ICollection<Email> Emails { get; set; }
        public ICollection<Skype> Skypes { get; set; }
        public ICollection<Address> Address { get; set; }

    }
}
