using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Identity;

namespace DAL.Repositories.Interfaces
{
    [Obsolete("Not used any more", true)]
    public interface IIdentityUnitOfWork : IDisposable
    {
        AppUserManager AppUserManager { get; }
        IUserManager UserManager { get; }
        AppRoleManager RoleManager { get; }

        Task SaveAsync();
        void Save();
    }
}
