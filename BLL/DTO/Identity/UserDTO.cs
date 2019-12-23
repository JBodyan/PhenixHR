using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO.Identity
{
    [Obsolete("Not used any more", true)]
    public class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}
