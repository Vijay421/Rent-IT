using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;

        public UserController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        /// <summary>
        /// Allows signed in user to logout.
        /// </summary>
        [Authorize]
        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("Uitgelogd");
        }

        /// <summary>
        /// Attempts to return the claims of the current logged in user.
        /// </summary>
        [Authorize]
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
        /// Endpoint to test anonymous users.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("everyone")]
        public ActionResult Everyone()
        {
            if (User.Identity.IsAuthenticated)
            {
                Console.WriteLine("huh?");
            }

            return Ok("Everyone");
        }

        /// <summary>
        /// Endpoint to test all users.
        /// </summary>
        [Authorize]
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
