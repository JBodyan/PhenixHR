using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace WEB.Data
{
    public class AppUser : IdentityUser<string>
    {
        public virtual UserDetails UserDetails { get; set; }
    }
}
