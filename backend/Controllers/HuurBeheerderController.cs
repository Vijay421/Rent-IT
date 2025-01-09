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
    }
}
