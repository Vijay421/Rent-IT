using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BackendTestProject
{
    public class MockUtils
    {
        public static ClaimsPrincipal CreateMockUser(string role, string id = "0")
        {
            return new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, role),
                    new Claim(ClaimTypes.NameIdentifier, id),
                },
                "mock"
            ));
        }

        public static ControllerContext CreateMockControllerContextWithUser(ClaimsPrincipal user)
        {
            return new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };
        }

        public static ControllerContext CreateMockControllerContext(string role, string id = "0")
        {
            return new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = CreateMockUser(role, id) }
            };
        }
    }
}
