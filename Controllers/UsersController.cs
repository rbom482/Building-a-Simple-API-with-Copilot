using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // Use a dictionary for O(1) lookups and updates
        private static Dictionary<int, User> users = new Dictionary<int, User>
        {
            { 1, new User { Id = 1, Name = "Alice", Email = "alice@example.com" } },
            { 2, new User { Id = 2, Name = "Bob", Email = "bob@example.com" } }
        };

        // GET: api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            try
            {
                return Ok(users.Values.ToList());
            }
            catch
            {
                return StatusCode(500, new { message = "An error occurred while retrieving users." });
            }
        }

        // GET: api/users/1
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            try
            {
                if (!users.TryGetValue(id, out var user))
                    return NotFound(new { message = $"User with ID {id} not found." });
                return Ok(user);
            }
            catch
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the user." });
            }
        }

        // POST: api/users
        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User user)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(user.Name))
                    return BadRequest(new { message = "Name is required." });

                if (string.IsNullOrWhiteSpace(user.Email) || !new EmailAddressAttribute().IsValid(user.Email))
                    return BadRequest(new { message = "A valid email is required." });

                if (users.Values.Any(u => u.Email == user.Email))
                    return Conflict(new { message = "A user with this email already exists." });

                user.Id = users.Keys.Any() ? users.Keys.Max() + 1 : 1;
                users[user.Id] = user;
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            catch
            {
                return StatusCode(500, new { message = "An error occurred while creating the user." });
            }
        }

        // PUT: api/users/1
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            try
            {
                if (!users.TryGetValue(id, out var user))
                    return NotFound(new { message = $"User with ID {id} not found." });

                if (string.IsNullOrWhiteSpace(updatedUser.Name))
                    return BadRequest(new { message = "Name is required." });

                if (string.IsNullOrWhiteSpace(updatedUser.Email) || !new EmailAddressAttribute().IsValid(updatedUser.Email))
                    return BadRequest(new { message = "A valid email is required." });

                if (users.Values.Any(u => u.Email == updatedUser.Email && u.Id != id))
                    return Conflict(new { message = "A user with this email already exists." });

                user.Name = updatedUser.Name;
                user.Email = updatedUser.Email;
                users[id] = user;
                return NoContent();
            }
            catch
            {
                return StatusCode(500, new { message = "An error occurred while updating the user." });
            }
        }

        // DELETE: api/users/1
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                if (!users.ContainsKey(id))
                    return NotFound(new { message = $"User with ID {id} not found." });

                users.Remove(id);
                return NoContent();
            }
            catch
            {
                return StatusCode(500, new { message = "An error occurred while deleting the user." });
            }
        }
    }
}