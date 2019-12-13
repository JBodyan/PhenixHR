using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities.Users
{
    public class UserDetails
    {
        [Key]
        [ForeignKey("AppUser")]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
