using backend.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivacyStatementController : ControllerBase
    {
        // File path where the privacy statement is stored
        //private static readonly string FilePath = "../backend/privacyStatement.txt";
        private static readonly string FilePath = "./privacyStatement.txt";

        // GET: api/PrivacyStatement
        [HttpGet]
        public ActionResult<string> GetPrivacyStatement()
        {
            // Check if the file exists, otherwise return a 404 Not Found response
            if (!System.IO.File.Exists(FilePath))
            {
                return NotFound("Privacy statement not found.");
            }

            // Read the privacy statement from the file and return it
            var statementText = System.IO.File.ReadAllText(FilePath);
            return Ok(new PrivacyStatementDTO { StatementText = statementText });
        }

        // PUT: api/PrivacyStatement
        [Authorize(Roles = "backoffice_medewerker")]
        [HttpPut]
        public ActionResult<PrivacyStatementDTO> UpdatePrivacyStatement(PrivacyStatementDTO privacyStatementDTO)
        {
            // Validate the input to ensure it's not null or empty
            if (privacyStatementDTO != null && !string.IsNullOrEmpty(privacyStatementDTO.StatementText))
            {
                // Save the updated privacy statement to the file
                System.IO.File.WriteAllText(FilePath, privacyStatementDTO.StatementText);

                // Return the updated privacy statement
                return Ok(new PrivacyStatementDTO { StatementText = privacyStatementDTO.StatementText });
            }

            // If the input is invalid, return a 400 Bad Request response
            return BadRequest("Invalid privacy statement text.");
        }
    }
}
