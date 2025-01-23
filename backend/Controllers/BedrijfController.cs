using backend.Data;
using backend.DTOs;
using backend.Models;
using backend.Models.Rollen;
using backend.Rollen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Security.Claims;

namespace backend.Controllers
{
    [Authorize(Roles = "bedrijf")]
    [Route("api/[controller]")]
    [ApiController]
    public class BedrijfController : ControllerBase
    {
        private readonly RentalContext _context;
        private readonly UserManager<User> _userManager;

        public BedrijfController(RentalContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> CreateBedrijf(CreateBedrijfDTO bedrijfDTO)
        {
            var user = new User
            {
                UserName = bedrijfDTO.UserName.Trim(),
                Email = bedrijfDTO.Email.ToLower().Trim(),
                PhoneNumber = bedrijfDTO?.PhoneNumber?.Trim(),
            };

            if (await _userManager.FindByNameAsync(bedrijfDTO.UserName) != null)
            {
                return UnprocessableEntity($"Naam: '{bedrijfDTO.UserName}' is al in gebruik");
            }

            var userWithEmail = await _userManager.FindByEmailAsync(bedrijfDTO.Email);
            if (userWithEmail != null)
            {
                return UnprocessableEntity($"E-mail: '{bedrijfDTO.Email}' is al in gebruik");
            }

            var result = await _userManager.CreateAsync(user, bedrijfDTO.Password.Trim());
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "bedrijf");

                var bedrijf = new Bedrijf
                {
                    Name = bedrijfDTO.BedrijfsNaam,
                    Address = bedrijfDTO.Address,
                    KvK_nummer = bedrijfDTO.KvK_nummer,
                    PhoneNumber = bedrijfDTO.PhoneNumber,
                    Domein = bedrijfDTO.Domein,
                };
                await _context.Bedrijven.AddAsync(bedrijf);
                await _context.SaveChangesAsync();

                user.Bedrijf = bedrijf;
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(CreateBedrijf), new { id = bedrijf.Id }, bedrijfDTO);
            }
            else
            {
                if (result.Errors.Any(e => e.Code == "DuplicateUserName"))
                {
                    return Conflict($"Naam '{bedrijfDTO.UserName}' is al in gebruikt");
                }

                var passwordErrors = result.Errors.Where(e => e.Code.StartsWith("Password"));
                if (passwordErrors.Any())
                {
                    return Conflict($"Ongeldig wachtwoord: het moet minimaal 1 hoofdletter, een getal en een niet alfanumeriek character bevatten");
                }

                var errorMsg = string.Join(", ", result.Errors.Select(e => e.Description));
                Console.Error.WriteLine($"error: {errorMsg}");

                return BadRequest("Kan de gebruikern niet aanmaken");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBedrijf(UpdateBedrijfDTO bedrijfDTO)
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
            _context.Entry(user).Reference(u => u.Bedrijf).Load();

            if (user.Bedrijf == null)
            {
                return Unauthorized("Incorrecte gebruiker");
            }

            var bedrijf = user.Bedrijf;

            bedrijf.Name = bedrijfDTO.Name ?? bedrijf.Name;
            bedrijf.Address = bedrijfDTO.Address ?? bedrijf.Address;
            bedrijf.KvK_nummer = bedrijfDTO.KvK_nummer ?? bedrijf.KvK_nummer;
            bedrijf.PhoneNumber = bedrijfDTO.PhoneNumber ?? bedrijf.PhoneNumber;
            bedrijf.Domein = bedrijfDTO.Domein ?? bedrijf.Domein;

            user.UserName = bedrijfDTO.UserName ?? user.UserName;
            user.Email = bedrijfDTO.Email ?? user.Email;
            user.PhoneNumber= bedrijfDTO.PhoneNumber ?? user.PhoneNumber;

            _context.Entry(bedrijf).State = EntityState.Modified;
            _context.Entry(user).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBedrijf()
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
            _context.Entry(user).Reference(u => u.Bedrijf).Load();

            if (user.Bedrijf == null)
            {
                return Unauthorized("Incorrecte gebruiker");
            }

            _context.Bedrijven.Remove(user.Bedrijf);
            await _userManager.DeleteAsync(user);

            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        [HttpPost("zakelijke_beheerder")]
        public async Task<ActionResult> CreateZakelijkeBeheerder(CreateHuurbeheerderDTO beheerderDTO)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id == null)
            {
                return NotFound("Kan de gebruiker niet vinden");
            }

            var bedrijf = await _userManager.FindByIdAsync(id);
            if (bedrijf == null)
            {
                return NotFound("Kan de gebruiker niet vinden");
            }
            _context.Entry(bedrijf).Reference(u => u.Bedrijf).Load();

            if (bedrijf.Bedrijf == null)
            {
                return Unauthorized("Incorrecte gebruiker");
            }

            var newUser = new User
            {
                UserName = beheerderDTO.Name.Trim(),
                Email = beheerderDTO.Email.ToLower().Trim(),
                PhoneNumber = beheerderDTO.PhoneNumber.Trim(),
            };

            if (await _userManager.FindByNameAsync(beheerderDTO.Name) != null)
            {
                return UnprocessableEntity($"Naam: '{beheerderDTO.Name}' is al in gebruik");
            }

            var userWithEmail = await _userManager.FindByEmailAsync(beheerderDTO.Email);
            if (userWithEmail != null)
            {
                return UnprocessableEntity($"E-mail: '{beheerderDTO.Email}' is al in gebruik");
            }

            var result = await _userManager.CreateAsync(newUser, beheerderDTO.Password.Trim());
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "zakelijke_beheerder");

                var huurBeheerder = new Huurbeheerder
                {
                    Id = 0, // The orm will define the id for us.
                    Bedrijfsrol = beheerderDTO.Bedrijfsrol,
                    BedrijfId = bedrijf.Bedrijf.Id,
                    Bedrijf = bedrijf.Bedrijf,
                };
                await _context.Huurbeheerders.AddAsync(huurBeheerder);
                await _context.SaveChangesAsync();

                newUser.Huurbeheerder = huurBeheerder;
                _context.Entry(newUser).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                if (result.Errors.Any(e => e.Code == "DuplicateUserName"))
                {
                    return BadRequest($"Naam '{beheerderDTO.Name}' is al in gebruikt");
                }

                var passwordErrors = result.Errors.Where(e => e.Code.StartsWith("Password"));
                if (passwordErrors.Any())
                {
                    return BadRequest($"Ongeldig wachtwoord: het moet minimaal 1 hoofdletter, een getal en een niet alfanumeriek character bevatten");
                }

                var errorMsg = string.Join(", ", result.Errors.Select(e => e.Description));
                Console.Error.WriteLine($"error: {errorMsg}");

                return BadRequest("Kan de gebruikern niet aanmaken");
            }

            return CreatedAtAction(nameof(CreateZakelijkeBeheerder), new { id = newUser.Id }, new { Id = newUser.Id, UserName = newUser.UserName });
        }

        [HttpGet("zakelijke_beheerders")]
        public async Task<ActionResult<IEnumerable<GetBeheerderDTO>>> GetHuurBeheerders()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id == null)
            {
                return NotFound("Kan de gebruiker niet vinden");
            }

            var bedrijf = await _userManager.FindByIdAsync(id);
            if (bedrijf == null)
            {
                return NotFound("Kan de gebruiker niet vinden");
            }
            _context.Entry(bedrijf).Reference(u => u.Bedrijf).Load();

            if (bedrijf.Bedrijf == null)
            {
                return Unauthorized("Incorrecte gebruiker");
            }
            _context.Entry(bedrijf.Bedrijf).Collection(b => b.Huurbeheerders).Load();

            bedrijf.Bedrijf.Huurbeheerders.ForEach(h =>
            {
                _context.Entry(h).Reference(h => h.User).Load();
                _context.Entry(h).Collection(h => h.ZakelijkeHuurders).Load();
            });

            var beheerders = bedrijf
                .Bedrijf
                .Huurbeheerders
                .Select(h => new
                {
                    Id = h.Id,
                    Bedrijfsrol = h.Bedrijfsrol,
                    UserName = h.User?.UserName,
                    ZakelijkeHuurders = h.ZakelijkeHuurders.Select(z => z.Id),
                })
                .ToList();

            return Ok(beheerders);
        }

        [HttpPost("zakelijke_huurder")]
        public async Task<ActionResult<UserDTO>> CreateZakelijkeHuurder(CreateZakelijkeHuurderDTO huurderDTO)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id == null)
            {
                return NotFound("Kan de gebruiker niet vinden");
            }

            var bedrijf = await _userManager.FindByIdAsync(id);
            if (bedrijf == null)
            {
                return NotFound("Kan de gebruiker niet vinden");
            }
            _context.Entry(bedrijf).Reference(u => u.Bedrijf).Load();

            if (bedrijf.Bedrijf == null)
            {
                return Unauthorized("Incorrecte gebruiker");
            }

            _context.Entry(bedrijf.Bedrijf).Collection(b => b.Huurbeheerders).Load();
            if (bedrijf.Bedrijf.Huurbeheerders.Count == 0)
            {
                return UnprocessableEntity("Huidig bedrijf heeft geen huurbeheerder; maak deze eerst aan.");
            }

            var huurbeheerder = bedrijf.Bedrijf.Huurbeheerders.FirstOrDefault(h => h.Id == huurderDTO.HuurbeheerderId);
            if (huurbeheerder == null)
            {
                return NotFound("Geen huurbeheeder gevonden");
            }

            var user = new User
            {
                UserName = huurderDTO.Name.Trim(),
                Email = huurderDTO.Email.ToLower().Trim(),
                PhoneNumber = huurderDTO.PhoneNumber.Trim(),
            };

            if (await _userManager.FindByNameAsync(huurderDTO.Name) != null)
            {
                return UnprocessableEntity($"Naam: '{huurderDTO.Name}' is al in gebruik");
            }

            var userWithEmail = await _userManager.FindByEmailAsync(huurderDTO.Email);
            if (userWithEmail != null)
            {
                return UnprocessableEntity($"E-mail: '{huurderDTO.Email}' is al in gebruik");
            }

            var result = await _userManager.CreateAsync(user, huurderDTO.Password.Trim());

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "zakelijke_huurder");

                var zakelijkeHuurder = new ZakelijkeHuurder
                {
                    Id = 0, // The orm will define the id for us.
                    Factuuradres = huurderDTO.Factuuradres
                };
                await _context.ZakelijkeHuurders.AddAsync(zakelijkeHuurder);
                await _context.SaveChangesAsync();

                user.ZakelijkeHuurder = zakelijkeHuurder;
                await _userManager.UpdateAsync(user);
                await _context.SaveChangesAsync();

                var beheerders = await _context
                    .Huurbeheerders
                    .Include(h => h.Bedrijf)
                    .Where(h => h.BedrijfId == bedrijf.BedrijfId)
                    .Include(h => h.ZakelijkeHuurders)
                    .ToListAsync();

                huurbeheerder.ZakelijkeHuurders.Add(zakelijkeHuurder);
                _context.Entry(huurbeheerder).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
            else
            {
                if (result.Errors.Any(e => e.Code == "DuplicateUserName"))
                {
                    return BadRequest($"Naam '{huurderDTO.Name}' is al in gebruikt");
                }

                var passwordErrors = result.Errors.Where(e => e.Code.StartsWith("Password"));
                if (passwordErrors.Any())
                {
                    return BadRequest($"Ongeldig wachtwoord: het moet minimaal 1 hoofdletter, een getal en een niet alfanumeriek character bevatten");
                }

                var errorMsg = string.Join(", ", result.Errors.Select(e => e.Description));
                Console.Error.WriteLine($"error: {errorMsg}");

                return BadRequest("Kan de gebruikern niet aanmaken");
            }

            return CreatedAtAction(nameof(CreateZakelijkeHuurder), new { id = user.Id }, new UserDTO { Id = user.Id, UserName = user.UserName });
        }
    }
}
