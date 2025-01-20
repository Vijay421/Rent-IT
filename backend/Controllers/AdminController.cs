using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using backend.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using backend.Rollen;
using System;
using System.Security.Claims;

namespace backend.Controllers
{
    [Authorize(Roles = "admin, backoffice_medewerker")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly RentalContext _context;
        private readonly UserManager<User> _userManager;

        public AdminController(RentalContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("employees")]
        public async Task<ActionResult<IEnumerable<GetEmployeeDTO>>> GetEmployees()
        {
            var employees = await _context
                .Users
                .Where(e => e.BackOfficeId != null || e.FrontOfficeId != null)
                .Select(e => new GetEmployeeDTO
                {
                    Id = e.Id,
                    UserName = e.UserName,
                    Email = e.Email,
                    Role = e.BackOfficeId != null ? "backoffice_medewerker" : "frontoffice_medewerker",
                    LockoutEnd = e.LockoutEnd,
                    LockoutEnabled = e.LockoutEnabled,
                    AccessFailedCount = e.AccessFailedCount,
                })
                .ToListAsync();

            return Ok(employees);
        }

        [HttpPost("unblock-employee/{id}")]
        public async Task<ActionResult<GetEmployeeDTO>> UnblockEmployee(string id)
        {
            var employee = await _userManager.FindByIdAsync(id);
            if (employee == null)
            {
                return NotFound($"Geen medewerker met id: '{id}'");
            }

            await _userManager.SetLockoutEndDateAsync(employee, DateTimeOffset.Now);

            return Ok(new GetEmployeeDTO
            {
                Id = employee.Id,
                UserName = employee.UserName,
                Email = employee.Email,
                Role = employee.BackOfficeId != null ? "backoffice_medewerker" : "frontoffice_medewerker",
                LockoutEnd = employee.LockoutEnd,
                LockoutEnabled = employee.LockoutEnabled,
                AccessFailedCount = employee.AccessFailedCount,
            });
        }

        [HttpPost("employee")]
        public async Task<ActionResult<UserDTO>> CreateEmployee(CreateEmployeeDTO createEmployeeDTO)
        {
            if (createEmployeeDTO.Role != "backoffice_medewerker" && createEmployeeDTO.Role != "frontoffice_medewerker")
            {
                return UnprocessableEntity($"Verkeerde rol; verwacht: backoffice of frontoffice, ontvangen: '{createEmployeeDTO.Role}'");
            }

            if (await _userManager.FindByNameAsync(createEmployeeDTO.Name) != null)
            {
                return Conflict($"Naam: '{createEmployeeDTO.Name}' is al in gebruik");
            }

            var userWithEmail = await _userManager.FindByEmailAsync(createEmployeeDTO.Email);
            if (userWithEmail != null)
            {
                return Conflict($"E-mail: '{createEmployeeDTO.Email}' is al in gebruik");
            }

            BackOfficeMedewerker? backoffice = null;
            if (createEmployeeDTO.Role == "backoffice_medewerker")
            {
                backoffice = new BackOfficeMedewerker();
                _context.BackOfficeMedewerkers.Add(backoffice);
                await _context.SaveChangesAsync();
            }

            FrontOfficeMedewerker? frontoffice = null;
            if (createEmployeeDTO.Role == "frontoffice_medewerker")
            {
                frontoffice = new FrontOfficeMedewerker();
                _context.FrontOfficeMedewerkers.Add(frontoffice);
                await _context.SaveChangesAsync();
            }

            var user = new User
            {
                UserName = createEmployeeDTO.Name.Trim(),
                Email = createEmployeeDTO.Email.ToLower().Trim(),
                PhoneNumber = createEmployeeDTO.PhoneNumber.Trim(),
                BackOffice = backoffice,
                Frontoffice = frontoffice,
            };

            var result = await _userManager.CreateAsync(user, createEmployeeDTO.Password.Trim());

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, createEmployeeDTO.Role);
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync(); // Adds the relation to the user.
            }
            else
            {
                if (result.Errors.Any(e => e.Code == "DuplicateUserName"))
                {
                    return Conflict($"Naam '{createEmployeeDTO.Name}' is al in gebruikt");
                }

                var passwordErrors = result.Errors.Where(e => e.Code.StartsWith("Password"));
                if (passwordErrors.Any())
                {
                    return UnprocessableEntity($"Ongeldig wachtwoord: het moet minimaal 1 hoofdletter, een getal en een niet alfanumeriek character bevatten");
                }

                var errorMsg = string.Join(", ", result.Errors.Select(e => e.Description));
                Console.Error.WriteLine($"error: {errorMsg}");

                return BadRequest("Kan de medewerker niet aanmaken");
            }

            return CreatedAtAction(nameof(CreateEmployee), new { id = user.Id }, new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Role = createEmployeeDTO.Role,
            });
        }

        [HttpPut("employee/{id}")]
        public async Task<ActionResult> UpdateEmployee(string id, UpdateEmployeeDTO updateEmployeeDTO)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound("Geen gebruiker gevonden");
            }

            if (updateEmployeeDTO.Password != null)
            {
                if (updateEmployeeDTO.CurrentPassword == null)
                {
                    return UnprocessableEntity("Vul het huidige wachtwoord in");
                }

                var pasChangeResult = await _userManager.ChangePasswordAsync(user, updateEmployeeDTO.CurrentPassword, updateEmployeeDTO.Password);
                if (!pasChangeResult.Succeeded)
                {
                    return UnprocessableEntity("Incorrect wachtwoord");
                }
            }

            user.UserName = updateEmployeeDTO.UserName ?? user.UserName;
            user.Email = updateEmployeeDTO.Email ?? user.Email;
            user.PhoneNumber = updateEmployeeDTO.PhoneNumber ?? user.PhoneNumber;

            _context.Entry(user).State = EntityState.Modified;

            _context.Entry(user).Reference(u => u.BackOffice).Load();
            _context.Entry(user).Reference(u => u.Frontoffice).Load();

            var isFrontOffice = await _userManager.IsInRoleAsync(user, "frontoffice_medewerker");
            if (updateEmployeeDTO.Role == "backoffice_medewerker" && isFrontOffice)
            {
                await _userManager.AddToRoleAsync(user, updateEmployeeDTO.Role);
                await _userManager.RemoveFromRoleAsync(user, "frontoffice_medewerker");

                if (user.Frontoffice != null)
                {
                    _context.FrontOfficeMedewerkers.Remove(user.Frontoffice);
                }

                if (user.BackOffice == null)
                {
                    var backOffice = new BackOfficeMedewerker();
                    _context.BackOfficeMedewerkers.Add(backOffice);
                    await _context.SaveChangesAsync();

                    user.BackOffice = backOffice;
                }

                _context.Entry(user).State = EntityState.Modified;
            }

            var isBackOffice = await _userManager.IsInRoleAsync(user, "backoffice_medewerker");
            if (updateEmployeeDTO.Role == "frontoffice_medewerker" && isBackOffice)
            {
                await _userManager.AddToRoleAsync(user, updateEmployeeDTO.Role);
                await _userManager.RemoveFromRoleAsync(user, "backoffice_medewerker");

                if (user.BackOffice != null)
                {
                    _context.BackOfficeMedewerkers.Remove(user.BackOffice);
                }

                if (user.Frontoffice == null)
                {
                    var frontOffice = new FrontOfficeMedewerker();
                    _context.FrontOfficeMedewerkers.Add(frontOffice);
                    await _context.SaveChangesAsync();

                    user.Frontoffice = frontOffice;
                }

                _context.Entry(user).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
