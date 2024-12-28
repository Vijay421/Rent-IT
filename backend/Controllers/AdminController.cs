using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using backend.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

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
                .Include( m => m.BackOffice)
                .Include(m => m.FrontOffice)
                .Where(m => m.BackOffice != null || m.FrontOffice != null)
                .Select(m => new GetEmployeeDTO
                {
                    Id = m.Id,
                    UserName = m.UserName,
                    Email = m.Email,
                    Role = m.BackOffice != null ? "backoffice_medewerker" : "frontoffice_medewerker",
                    LockoutEnd = m.LockoutEnd,
                    LockoutEnabled = m.LockoutEnabled,
                    AccessFailedCount = m.AccessFailedCount,
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
                return NotFound($"Geen medewerker met id: {id}");
            }

            await _userManager.SetLockoutEndDateAsync(employee, DateTimeOffset.Now);

            _context.Entry(employee).Reference(e => e.BackOffice).Load();
            _context.Entry(employee).Reference(e => e.FrontOffice).Load();

            return Ok(new GetEmployeeDTO
            {
                Id = employee.Id,
                UserName = employee.UserName,
                Email = employee.Email,
                Role = employee.BackOffice != null ? "backoffice_medewerker" : "frontoffice_medewerker",
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

            var user = new User
            {
                UserName = createEmployeeDTO.Name.Trim(),
                Email = createEmployeeDTO.Email.ToLower().Trim(),
                PhoneNumber = createEmployeeDTO.PhoneNumber.Trim(),
            };

            if (await _userManager.FindByNameAsync(createEmployeeDTO.Name) != null)
            {
                return Conflict($"Naam: '{createEmployeeDTO.Name}' is al in gebruik");
            }

            var userWithEmail = await _userManager.FindByEmailAsync(createEmployeeDTO.Email);
            if (userWithEmail != null)
            {
                return Conflict($"E-mail: '{createEmployeeDTO.Email}' is al in gebruik");
            }

            var result = await _userManager.CreateAsync(user, createEmployeeDTO.Password.Trim());

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "particuliere_huurder");
                await _userManager.UpdateAsync(user);
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
