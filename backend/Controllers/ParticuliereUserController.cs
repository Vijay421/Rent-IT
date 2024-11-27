using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticuliereUserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RentalContext _context;
        private readonly ILogger<ParticuliereUserController> _logger;

        public ParticuliereUserController(RentalContext context, UserManager<User> userManager, ILogger<ParticuliereUserController> logger)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
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

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(string id, UpdateParticuliereHuurderDTO huurderDTO)
        {
            if (!huurderDTO.HasData())
            {
                return BadRequest();
            }

            if (huurderDTO.Id != id)
            {
                return BadRequest();
            }

            //var user = await _userManager.GenerateUserTokenAsync();
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.UserName = huurderDTO.UserName ?? user.UserName;
            user.Email = huurderDTO.Email ?? user.Email;
            user.PhoneNumber = huurderDTO.PhoneNumber ?? user.PhoneNumber;

            if (huurderDTO.Address != null)
            {
                _context.Entry(user).Reference(u => u.ParticuliereHuurder).Load();
                if (user.ParticuliereHuurder != null)
                {
                    user.ParticuliereHuurder.Address = huurderDTO.Address;
                }
            }

            if (huurderDTO.Password != null)
            {
                if (huurderDTO.CurrentPassword == null)
                {
                    return BadRequest();
                }

                await _userManager.ChangePasswordAsync(user, huurderDTO.CurrentPassword, huurderDTO.Password);
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Users.Any(u => u.Id == id))
                {
                    return NotFound();
                } else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }
}
