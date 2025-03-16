using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCase;

namespace Application.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleUseCase _roleUseCase;

        public RoleController(IRoleUseCase roleUseCase)
        {
            _roleUseCase = roleUseCase;
        }

        // Get Role by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDTO>> GetRoleById(Guid id)
        {
            var role = await _roleUseCase.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        // Get Role by Name
        [HttpGet("name")]
        public async Task<ActionResult<RoleDTO>> GetRoleByName([FromQuery] string name)
        {
            var role = await _roleUseCase.GetRoleByName(name);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        // Create a new Role
        [HttpPost]
        public async Task<ActionResult<RoleDTO>> CreateRole([FromBody] RoleDTO roleDTO)
        {
            var createdRole = await _roleUseCase.CreateNewRole(roleDTO);
            return CreatedAtAction(nameof(GetRoleById), new { id = createdRole.RoleId }, createdRole);
        }

        // Get all Roles
        [HttpGet]
        public async Task<ActionResult<List<RoleDTO>>> GetAllRoles()
        {
            var roles = await _roleUseCase.FetchAllRoles();
            return Ok(roles);
        }

        // Delete Role by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleById(Guid id)
        {
            var roleExists = await _roleUseCase.GetRoleById(id);
            if (roleExists == null)
            {
                return NotFound();
            }

            await _roleUseCase.DeleteRoleById(id);
            return NoContent();
        }

        // Delete Role by Name
        [HttpDelete]
        public async Task<IActionResult> DeleteRoleByName([FromQuery] string name)
        {
            var roleExists = await _roleUseCase.GetRoleByName(name);
            if (roleExists == null)
            {
                return NotFound();
            }

            await _roleUseCase.DeleteRoleByName(name);
            return NoContent();
        }
    }
}
