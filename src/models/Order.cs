namespace programacionIII_crud.Models;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "Pending";
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation property
    public User? User { get; set; }
}
