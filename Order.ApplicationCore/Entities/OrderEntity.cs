namespace Order.ApplicationCore.Entities;

public class OrderEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime OrderDateTime { get; set; }
    public decimal TotalPrice { get; set; }
    public ICollection<OrderItem>? OrderItems { get; set; }
}