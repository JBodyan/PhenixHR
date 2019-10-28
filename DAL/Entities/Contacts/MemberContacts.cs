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
        public Phone Phone { get; set; }
        public Phone SecondPhone { get; set; }
        public Email Email { get; set; }
        public Skype Skype { get; set; }
        public Address Address { get; set; }

    }
}
