using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.UseCase
{
    public interface IRoleUseCase
    {
        Task<RoleDTO> GetRoleById(Guid roleId);
        Task<RoleDTO> CreateNewRole(RoleDTO role);
        Task<List<RoleDTO>> FetchAllRoles();
        Task<RoleDTO> GetRoleByName(string roleName);
        Task DeleteRoleById(Guid roleId);
        Task DeleteRoleByName(string roleName);
    }
}
