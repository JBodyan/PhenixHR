using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities.Users;
using Microsoft.AspNet.Identity;

namespace DAL.Identity
{
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store) : base(store)
        {
        }
    }
}
