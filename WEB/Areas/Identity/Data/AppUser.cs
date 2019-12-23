using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace WEB.Data
{
    public class AppUser : IdentityUser<string>
    {
        public virtual UserDetails UserDetails { get; set; }
    }
}
