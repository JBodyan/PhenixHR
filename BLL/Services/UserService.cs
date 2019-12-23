using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO.Identity;
using BLL.ExceptionStructure;
using BLL.Interfaces;
using DAL.Entities.Users;
using DAL.Repositories.Interfaces;
using Microsoft.AspNet.Identity;

namespace BLL.Services
{
    [Obsolete("Not used any more", true)]
    public class UserService : IUserService
    {
        private readonly IIdentityUnitOfWork _db;

        public UserService(IIdentityUnitOfWork db)
        {
            _db = db;
        }

        public async Task<OperationDetails> CreateAsync(UserDTO userDto)
        {
            var user = await _db.AppUserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new AppUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await _db.AppUserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Any())
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
               
                await _db.AppUserManager.AddToRoleAsync(user.Id, userDto.Role);
                
                var userDetails = new UserDetails { Id = user.Id, Phone = userDto.Phone, Name = userDto.Name };
                _db.UserManager.Create(userDetails);
                await _db.SaveAsync();
                return new OperationDetails(true, "Register successed", "");
            }
            else
            {
                return new OperationDetails(false, "User exist", "Email");
            }
        }

        public async Task<ClaimsIdentity> AuthenticateAsync(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            
            var user = await _db.AppUserManager.FindAsync(userDto.Email, userDto.Password);
            
            if (user != null)
                claim = await _db.AppUserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        
        public async Task SetInitialDataAsync(UserDTO adminDto, List<string> roles)
        {
            foreach (var roleName in roles)
            {
                var role = await _db.RoleManager.FindByNameAsync(roleName);
                if (role != null) continue;
                role = new AppRole { Name = roleName };
                await _db.RoleManager.CreateAsync(role);
            }
            await CreateAsync(adminDto);
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
