using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.UseCase
{
    public interface IUserUseCase
    {
        Task<UserDTO> GetUserById(Guid userId);
        Task<UserDTO> GetUserByUsername(string username);
        Task<List<UserDTO>> GetAllUsers();
        Task<UserDTO> CreateUser(UserDTO user);
        Task DeleteUser(Guid userId);
        Task<List<RoleDTO>> GetUserRoles(Guid userId);
        Task<UserDTO> UpdateUser(Guid userId, UserDTO updatedUser);
        Task<UserDTO> AddRoleToUser(Guid userId, Guid roleId);
        Task<UserDTO> RemoveRoleFromUser(Guid userId, Guid roleId);
        Task<UserDTO> RemoveAllRolesFromUser(Guid userId);
    }
}
