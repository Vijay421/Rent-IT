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
        public static ClaimsPrincipal CreateMockUser(string role)
        {
            return new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, role),
                },
                "mock"
            ));
        }

        public static ControllerContext CreateMockControllerContext(ClaimsPrincipal user)
        {
            return new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };
        }
    }
}
