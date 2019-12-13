using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO.Identity;
using BLL.ExceptionStructure;

namespace BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> CreateAsync(UserDTO userDto);
        Task<ClaimsIdentity> AuthenticateAsync(UserDTO userDto);
        Task SetInitialDataAsync(UserDTO adminDto, List<string> roles);
    }
}
