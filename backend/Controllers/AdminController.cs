using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using backend.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using backend.Rollen;
using System;

namespace backend.Controllers
{
    [Authorize(Roles = "admin")]
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
    }
}
