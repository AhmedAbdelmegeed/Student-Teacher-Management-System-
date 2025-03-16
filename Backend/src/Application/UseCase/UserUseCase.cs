using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Application.DTO;
using Application.Service;


namespace Application.UseCase
{
    public class UserUseCase : IUserUseCase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserUseCase(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<UserDTO> GetUserById(Guid userId)
        {
            var user = await userService.FindByIdAsync(userId);
            return user != null ? mapper.Map<UserDTO>(user) : null;
        }

        public async Task<UserDTO> GetUserByUsername(string username)
        {
            var user = await userService.FindByUsernameAsync(username);
            return user != null ? mapper.Map<UserDTO>(user) : null;
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = await userService.GetAllUsersAsync();
            return users.Select(user => mapper.Map<UserDTO>(user)).ToList();
        }

        public async Task<UserDTO> CreateUser(UserDTO userDTO)
        {
            var user = mapper.Map<User>(userDTO);
            var createdUser = await userService.CreateUserAsync(user);
            return mapper.Map<UserDTO>(createdUser);
        }

        public async Task DeleteUser(Guid userId)
        {
            await userService.DeleteUserAsync(userId);
        }

        public async Task<List<RoleDTO>> GetUserRoles(Guid userId)
        {
            var user = await userService.FindByIdAsync(userId);
            if (user == null) return new List<RoleDTO>();

            return user.UserRoles.Select(role => mapper.Map<RoleDTO>(role)).ToList();
        }

        public async Task<UserDTO> UpdateUser(Guid userId, UserDTO updatedUser)
        {
            var user = mapper.Map<User>(updatedUser);
            var updated = await userService.UpdateUserAsync(userId, user);
            return mapper.Map<UserDTO>(updated);
        }

        public async Task<UserDTO> AddRoleToUser(Guid userId, Guid roleId)
        {
            var updatedUser = await userService.AddRoleToUserAsync(userId, roleId);
            return mapper.Map<UserDTO>(updatedUser);
        }

        public async Task<UserDTO> RemoveRoleFromUser(Guid userId, Guid roleId)
        {
            var updatedUser = await userService.RemoveRoleFromUserAsync(userId, roleId);
            return mapper.Map<UserDTO>(updatedUser);
        }

        public async Task<UserDTO> RemoveAllRolesFromUser(Guid userId)
        {
            var updatedUser = await userService.RemoveAllRolesFromUserAsync(userId);
            return mapper.Map<UserDTO>(updatedUser);
        }
    }
}
