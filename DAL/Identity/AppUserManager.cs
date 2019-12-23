using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities.Users;
using Microsoft.AspNet.Identity;

namespace DAL.Identity
{
    [Obsolete("Not used any more", true)]
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store) : base(store)
        {
        }
    }
}
