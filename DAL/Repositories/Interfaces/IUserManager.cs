using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.Users;

namespace DAL.Repositories.Interfaces
{
    [Obsolete("Not used any more", true)]
    public interface IUserManager : IDisposable
    {
        void Create(UserDetails item);
        Task CreateAsync(UserDetails item);
    }
}
