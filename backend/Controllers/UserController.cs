using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public UserController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        /// <summary>
        /// Allows signed in users to logout.
        /// </summary>
        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("Uitgelogd");
        }

        /// <summary>
        /// Attempts to return the claims of the current logged in user.
        /// </summary>
        [HttpGet("claims")]
        public async Task<ActionResult> GetClaims()
        {
            var CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (CurrentUserId == null)
            {
                return Unauthorized("Kan gebruiker niet vinden");
            }

            var CurrentUserName = User.FindFirstValue(ClaimTypes.Name);
            var CurrentUserRole = User.FindFirstValue(ClaimTypes.Role);

            return Ok(new
            {
                UserId = CurrentUserId,
                UserName = CurrentUserName,
                Role = CurrentUserRole,
            });
        }

        /// <summary>
        /// Attempt to the delete the current logged in user.
        /// Won't work when deleting a different user,
        /// or if the user could not be found.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId == null)
            {
                return NotFound("Kan de gebruiker niet vinden");
            }

            if (currentUserId != id)
            {
                return Unauthorized("Kan de gebruiker niet vinden");
            }

            var user = await _userManager.FindByIdAsync(currentUserId);
            if (user == null)
            {
                return NotFound("Kan de gebruiker niet vinden");
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                var errorMsg = string.Join(", ", result.Errors.Select(e => e.Description));
                Console.Error.WriteLine(errorMsg);

                return BadRequest("Kon de gebruiker niet verwijderen.");
            }

            return NoContent();
        }

        /// <summary>
        /// Endpoint to test anonymous users.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("everyone")]
        public ActionResult Everyone()
        {
            if (User.Identity.IsAuthenticated)
            {
                Console.WriteLine("is logged in");
            }

            return Ok("Everyone");
        }

        /// <summary>
        /// Endpoint to test all users.
        /// </summary>
        [HttpGet("users-only")]
        public ActionResult UsersOnly()
        {
            return Ok("UsersOnly");
        }

        /// <summary>
        /// Endpoint to test the admin role.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpGet("admins-only")]
        public ActionResult AdminsOnly()
        {
            return Ok("AdminsOnly");
        }
    }
}
