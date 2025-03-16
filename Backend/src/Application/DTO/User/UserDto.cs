using System;
using System.Collections.Generic;

namespace Application.DTO
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<RoleDTO> Roles { get; set; } = new List<RoleDTO>();
    }
}
