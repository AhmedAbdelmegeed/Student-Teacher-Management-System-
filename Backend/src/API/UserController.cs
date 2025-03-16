using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Services;
using Application.DTO;
using Application.UseCase;

namespace YourNamespace.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserUseCase userUseCase;

        public UserController(IUserUseCase userUseCase)
        {
            this.userUseCase = userUseCase;
        }

        [HttpGet]
        public ActionResult<List<UserDTO>> GetAllUsers()
        {
            return Ok(userUseCase.GetAllUsers());
        }

        [HttpGet("{userId}")]
        public ActionResult<UserDTO> GetUserById(Guid userId)
        {
            var user = userUseCase.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("username/{username}")]
        public ActionResult<UserDTO> GetUserByUsername(string username)
        {
            var user = userUseCase.GetUserByUsername(username);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<UserDTO> CreateUser([FromBody] UserDTO userDTO)
        {
            var createdUser = userUseCase.CreateUser(userDTO);
            return CreatedAtAction(nameof(GetUserById), new { userId = createdUser.Id }, createdUser);
        }

        [HttpPut("{userId}")]
        public ActionResult<UserDTO> UpdateUser(Guid userId, [FromBody] UserDTO updatedUser)
        {
            var updated = userUseCase.UpdateUser(userId, updatedUser);
            if (updated == null)
            {
                return NotFound();
            }
            return Ok(updated);
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(Guid userId)
        {
            userUseCase.DeleteUser(userId);
            return NoContent(); // Successful deletion
        }

        [HttpGet("{userId}/roles")]
        public ActionResult<List<RoleDTO>> GetUserRoles(Guid userId)
        {
            var roles = userUseCase.GetUserRoles(userId);
            return Ok(roles);
        }

        [HttpPost("{userId}/roles/{roleId}")]
        public ActionResult<UserDTO> AddRoleToUser(Guid userId, Guid roleId)
        {
            var updatedUser = userUseCase.AddRoleToUser(userId, roleId);
            return Ok(updatedUser);
        }

        [HttpDelete("{userId}/roles/{roleId}")]
        public ActionResult<UserDTO> RemoveRoleFromUser(Guid userId, Guid roleId)
        {
            var updatedUser = userUseCase.RemoveRoleFromUser(userId, roleId);
            return Ok(updatedUser);
        }

        [HttpDelete("{userId}/role")]
        public ActionResult<UserDTO> RemoveAllRolesFromUser(Guid userId)
        {
            var updatedUser = userUseCase.RemoveAllRolesFromUser(userId);
            return Ok(updatedUser);
        }
    }
}