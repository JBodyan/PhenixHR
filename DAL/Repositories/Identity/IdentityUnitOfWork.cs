using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Entities.Users;
using DAL.Identity;
using DAL.Repositories.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Repositories.Identity
{
    public class IdentityUnitOfWork : IIdentityUnitOfWork
    {

        private readonly AppIdentityContext _db;
        private AppUserManager _appUserManager;
        private IUserManager _userManager;
        private AppRoleManager _roleManager;

        public IdentityUnitOfWork(string connectionString)
        {
            _db = new AppIdentityContext(connectionString);
        }

        public AppUserManager AppUserManager
        {
            get
            {
                if (_appUserManager == null)
                    _appUserManager = new AppUserManager(new UserStore<AppUser>(_db));
                return _appUserManager;
            }
        }

        public IUserManager UserManager
        {
            get
            {
                if (_userManager == null)
                    _userManager = new UserManager(_db);
                return _userManager;
            }
        }
        public AppRoleManager RoleManager
        {
            get
            {
                if (_roleManager == null)
                    _roleManager = new AppRoleManager(new RoleStore<AppRole>(_db));
                return _roleManager;
            }
        }
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
