using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Entities.Users
{
    [Obsolete("Not used any more", true)]
    public class AppUser : IdentityUser
    {
        public virtual UserDetails UserDetails { get; set; }
    }
}
