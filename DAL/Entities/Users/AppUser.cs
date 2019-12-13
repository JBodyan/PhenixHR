using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Entities.Users
{
    public class AppUser : IdentityUser
    {
        public virtual UserDetails UserDetails { get; set; }
    }
}
