using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Entities.Users;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Identity
{
    [Obsolete("Not used any more", true)]
    public class UserManager : IUserManager
    {
        private readonly AppIdentityContext _db;
        public UserManager(AppIdentityContext db)
        {
            _db = db;
        }

        public void Create(UserDetails item)
        {
            _db.AppUsers.Add(item);
            _db.SaveChanges();
        }

        public async Task CreateAsync(UserDetails item)
        {
            _db.AppUsers.Add(item);
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
