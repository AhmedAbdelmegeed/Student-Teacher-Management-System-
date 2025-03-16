using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Infrastructure.Repository;

namespace Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleService _roleService;

        public UserService(IUserRepository userRepository, IRoleService roleService)
        {
            _userRepository = userRepository;
            _roleService = roleService;
        }

        public async Task<User> FindByIdAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return (await _userRepository.GetAllAsync()).ToList();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await _userRepository.AddAsync(user);
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            await _userRepository.DeleteAsync(user);
        }

        public async Task<List<Role>> GetUserRolesAsync(Guid userId)
        {
            var user = await FindByIdAsync(userId);
            return user.UserRoles.ToList();
        }

        public async Task<User> UpdateUserAsync(Guid userId, User updatedUser)
        {
            var user = await FindByIdAsync(userId);

            if (!string.IsNullOrEmpty(updatedUser.Username))
            {
                user.Username = updatedUser.Username;
            }
            if (!string.IsNullOrEmpty(updatedUser.Email))
            {
                user.Email = updatedUser.Email;
            }
            if (!string.IsNullOrEmpty(updatedUser.FirstName))
            {
                user.FirstName = updatedUser.FirstName;
            }
            if (!string.IsNullOrEmpty(updatedUser.LastName))
            {
                user.LastName = updatedUser.LastName;
            }
            if (!string.IsNullOrEmpty(updatedUser.Password))
            {
                user.Password = updatedUser.Password;
            }

            return await _userRepository.AddAsync(user);
        }

        public async Task<User> AddRoleToUserAsync(Guid userId, Guid roleId)
        {
            var user = await FindByIdAsync(userId);
            var role = await _roleService.GetRole(roleId);
            user.UserRoles.Add(role);
            return await _userRepository.AddAsync(user);
        }

        public async Task<User> RemoveRoleFromUserAsync(Guid userId, Guid roleId)
        {
            var user = await FindByIdAsync(userId);
            var role = await _roleService.GetRole(roleId);
            user.UserRoles.Remove(role);
            return await _userRepository.AddAsync(user);
        }

        public async Task<User> RemoveAllRolesFromUserAsync(Guid userId)
        {
            var user = await FindByIdAsync(userId);
            user.UserRoles.Clear();
            return await _userRepository.AddAsync(user);
        }
    }
}