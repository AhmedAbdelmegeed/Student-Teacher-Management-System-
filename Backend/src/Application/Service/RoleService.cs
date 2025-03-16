using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;
using Application.Service;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace YourNamespace.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        // Constructor injection for RoleRepository
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        // Get a Role by its Id
        public async Task<Role> GetRole(Guid roleId)
        {
            var role = await _roleRepository.GetByIdAsync(roleId);
            if (role == null)
            {
                throw new Exception("Role not found");
            }
            return role;
        }

        // Create a new Role
        public async Task<Role> CreateRole(Role role)
        {
            return await _roleRepository.AddAsync(role);
        }

        // Get all Roles
        public async Task<List<Role>> GetAllRoles()
        {
            return (await _roleRepository.GetAllAsync()).ToList();
        }

        // Find a Role by its name
        public async Task<Role> FindByRoleName(string roleName)
        {
            var role = await _roleRepository.GetByNameAsync(roleName);
            if (role == null)
            {
                throw new Exception("Role not found with name: " + roleName);
            }
            return role;
        }

        // Delete a Role by its Id
        public async Task DeleteRole(Guid roleId)
        {
            var role = await _roleRepository.GetByIdAsync(roleId);
            await _roleRepository.DeleteAsync(role);
        }

        // Delete a Role by its name
        public async Task DeleteRole(string roleName)
        {
            var role = await _roleRepository.GetByNameAsync(roleName);
            await _roleRepository.DeleteAsync(role);
        }
    }
}
