using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities.Users;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class AppIdentityContext : IdentityDbContext<AppUser>
    {
        public AppIdentityContext(string conectionString) : base(conectionString) { }

        public DbSet<UserDetails> AppUsers { get; set; }
    }
}
