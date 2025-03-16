using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Application.Service
{
    public interface IRoleService
    {
        Task<Role> GetRole(Guid roleId);
        Task<Role> CreateRole(Role role);
        Task<List<Role>> GetAllRoles();
        Task<Role> FindByRoleName(string roleName);
        Task DeleteRole(Guid roleId);
        Task DeleteRole(string roleName);
    }
}
