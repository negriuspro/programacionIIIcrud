using Microsoft.AspNetCore.Mvc;
using programacionIII_crud.Models;

namespace programacionIII_crud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private static List<Payment> _payments = new();
    
    [HttpGet]
    public IActionResult GetAllPayments()
    {
        return Ok(_payments);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetPayment(int id)
    {
        var payment = _payments.FirstOrDefault(p => p.Id == id);
        if (payment == null)
            return NotFound(new { message = "Payment not found" });
            
        return Ok(payment);
    }
    
    [HttpPost]
    public IActionResult ProcessPayment([FromBody] Payment payment)
    {
        payment.Id = _payments.Count + 1;
        payment.PaymentDate = DateTime.Now;
        payment.TransactionId = Guid.NewGuid().ToString();
        
        // TODO: Implement real payment processing
        payment.Status = "Completed";
        
        _payments.Add(payment);
        
        return CreatedAtAction(nameof(GetPayment), new { id = payment.Id }, payment);
    }
    
    [HttpGet("order/{orderId}")]
    public IActionResult GetPaymentsByOrder(int orderId)
    {
        var payments = _payments.Where(p => p.OrderId == orderId).ToList();
        return Ok(payments);
    }
}
