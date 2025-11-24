using Microsoft.AspNetCore.Mvc;

namespace programacionIII_crud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    [HttpGet("stats")]
    public IActionResult GetDashboardStats()
    {
        // TODO: Implement real statistics
        var stats = new
        {
            totalUsers = 0,
            totalOrders = 0,
            totalRevenue = 0m,
            pendingPayments = 0
        };
        
        return Ok(stats);
    }
    
    [HttpGet("recent-activity")]
    public IActionResult GetRecentActivity()
    {
        // TODO: Implement recent activity tracking
        var activities = new List<object>();
        
        return Ok(activities);
    }
}
