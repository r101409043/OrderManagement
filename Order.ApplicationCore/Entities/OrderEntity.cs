namespace Order.ApplicationCore.Entities;

public class OrderEntity
{
    public int Id { get; init; }
    public int UserId { get; set; }
    public DateTime OrderDateTime { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; } = "Pending";
    public ICollection<OrderItem>? OrderItems { get; set; }
}