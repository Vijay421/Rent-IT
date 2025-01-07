using backend.Data;
using backend.DTOs;
using backend.Models;
using backend.Rollen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace backend.Controllers
{
    [Authorize(Roles = "zakelijke_beheerder")]
    [Route("api/[controller]")]
    [ApiController]
    public class HuurBeheerderController : ControllerBase
    {
        private readonly RentalContext _context;
        private readonly UserManager<User> _userManager;

        public HuurBeheerderController(RentalContext context, UserManager<User> userManager)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userManager = userManager;
        }

        [HttpGet("zakelijke-huurders")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetZakelijkeHuurders()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id == null)
            {
                return NotFound("Kan de gebruiker niet vinden");
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound("Kan de gebruiker niet vinden");
            }

            _context.Entry(user).Reference(u => u.Huurbeheerder).Load();
            if (user.Huurbeheerder == null)
            {
                return Unauthorized("Incorrecte gebruiker");
            }

            _context.Entry(user.Huurbeheerder).Reference(h => h.Bedrijf).Load();
            if (user.Huurbeheerder.Bedrijf == null)
            {
                return UnprocessableEntity("Huidige gebruiker is niet gekoppeld aan een bedrijf");
            }

            var domein = user.Huurbeheerder.Bedrijf.Domein;

            var huurders = await _context
                .Users
                .Include(u => u.ZakelijkeHuurder)
                .ThenInclude(z => z.User)
                .Where(u => u.ZakelijkeHuurder.HuurbeheerderId == user.Huurbeheerder.Id && u.Email.Contains(domein))
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    UserName = u.UserName,
                })
                .ToListAsync();

            return Ok(huurders);
        }
    }
}
