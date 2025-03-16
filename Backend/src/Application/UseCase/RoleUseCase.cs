using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Application.Service;
using Application.DTO;
using Domain.Entity;

namespace Application.UseCase
{
    public class RoleUseCase : IRoleUseCase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        // Injecting IRoleService (business logic) and IMapper (AutoMapper)
        public RoleUseCase(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        public async Task<RoleDTO> GetRoleById(Guid roleId)
        {
            var role = await _roleService.GetRole(roleId);
            return _mapper.Map<RoleDTO>(role);
        }

        public async Task<RoleDTO> CreateNewRole(RoleDTO role)
        {
            var roleEntity = _mapper.Map<Role>(role);  // Map DTO to Entity
            var createdRole = await _roleService.CreateRole(roleEntity);
            return _mapper.Map<RoleDTO>(createdRole); // Map Entity to DTO
        }

        public async Task<List<RoleDTO>> FetchAllRoles()
        {
            var roles = await _roleService.GetAllRoles();
            return roles.Select(role => _mapper.Map<RoleDTO>(role)).ToList();
        }

        public async Task<RoleDTO> GetRoleByName(string roleName)
        {
            var role = await _roleService.FindByRoleName(roleName);
            return _mapper.Map<RoleDTO>(role);
        }

        public async Task DeleteRoleById(Guid roleId)
        {
            await _roleService.DeleteRole(roleId);
        }

        public async Task DeleteRoleByName(string roleName)
        {
            await _roleService.DeleteRole(roleName);
        }
    }
}
