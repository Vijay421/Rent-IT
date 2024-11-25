using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticuliereUserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RentalContext _context;

        public ParticuliereUserController(RentalContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterParticuliereHuurderDTO huuder)
        {
            var user = new User
            {
                UserName = huuder.Name.Trim(),
                Email = huuder.Email.ToLower().Trim(),
                PhoneNumber = huuder.PhoneNumber.Trim(),
            };

            var result = await _userManager.CreateAsync(user, huuder.Password.Trim());

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "particuliere_huurder");

                // When the user has been created: make a ParticuliereHuurder.
                var particuliereHuurder = new ParticuliereHuurder
                {
                    Id = 0, // The orm will define the id for us.
                    Address = huuder.Address,
                };
                await _context.ParticuliereHuurders.AddAsync(particuliereHuurder);
                await _context.SaveChangesAsync();

                user.ParticuliereHuurder = particuliereHuurder;
                await _userManager.UpdateAsync(user);
            }
            else
            {
                var errorText = string.Join(", ", result.Errors.Select(e => e.Description));
                Console.Error.WriteLine($"error: {errorText}");

                return BadRequest("Unable to create user");
            }

            return Ok();
        }
    }
}
