using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

public interface IUserService
{
    Task<User> FindByIdAsync(Guid userId);
    Task<User> FindByUsernameAsync(string username);
    Task<List<User>> GetAllUsersAsync();
    Task<User> CreateUserAsync(User user);
    Task DeleteUserAsync(Guid userId);
    Task<List<Role>> GetUserRolesAsync(Guid userId);
    Task<User> UpdateUserAsync(Guid userId, User updatedUser);
    Task<User> AddRoleToUserAsync(Guid userId, Guid roleId);
    Task<User> RemoveRoleFromUserAsync(Guid userId, Guid roleId);
    Task<User> RemoveAllRolesFromUserAsync(Guid userId);
}
