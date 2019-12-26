using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebPhenix.Data
{
    public sealed class AppRole : IdentityRole<string>
    {
        public AppRole() { }

        public AppRole(string name)
        {
            Name = name;
        }
    }
}
