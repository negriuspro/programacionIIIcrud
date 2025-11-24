using Microsoft.AspNetCore.Mvc;
using programacionIII_crud.Models;

namespace programacionIII_crud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    [HttpPost]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // TODO: Implement authentication logic
        if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
        {
            return BadRequest(new { message = "Username and password are required" });
        }
        
        // Mock response
        return Ok(new { message = "Login successful", userId = 1 });
    }
}

public class LoginRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
