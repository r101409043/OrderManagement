namespace Order.ApplicationCore.Entities;

public class ShoppingCart
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }

    public ICollection<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
}