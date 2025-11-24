using Microsoft.AspNetCore.Mvc;
using programacionIII_crud.Models;

namespace programacionIII_crud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private static List<User> _users = new();
    
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        return Ok(_users);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null)
            return NotFound(new { message = "User not found" });
            
        return Ok(user);
    }
    
    [HttpPost]
    public IActionResult CreateUser([FromBody] User user)
    {
        user.Id = _users.Count + 1;
        user.CreatedAt = DateTime.Now;
        _users.Add(user);
        
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User user)
    {
        var existingUser = _users.FirstOrDefault(u => u.Id == id);
        if (existingUser == null)
            return NotFound(new { message = "User not found" });
            
        existingUser.Username = user.Username;
        existingUser.Email = user.Email;
        existingUser.FullName = user.FullName;
        existingUser.UpdatedAt = DateTime.Now;
        
        return Ok(existingUser);
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null)
            return NotFound(new { message = "User not found" });
            
        _users.Remove(user);
        return NoContent();
    }
}
