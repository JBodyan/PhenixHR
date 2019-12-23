using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities.Users;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace WEB.Data.Identity
{
    public class AppIdentityContext : IdentityDbContext
    {
        public AppIdentityContext(string conectionString) : base(conectionString) { }

        public DbSet<UserDetails> AppUsers { get; set; }
    }
}
