namespace programacionIII_crud.Models;

public class Payment
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending";
    public DateTime PaymentDate { get; set; } = DateTime.Now;
    public string? TransactionId { get; set; }
    
    // Navigation property
    public Order? Order { get; set; }
}
