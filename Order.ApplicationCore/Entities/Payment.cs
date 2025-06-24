namespace Order.ApplicationCore.Entities;

public class Payment
{
    public int Id { get; init; }
    public int CustomerId { get; init; }
    public string? Method { get; init; }
    public decimal Amount { get; init; }
    public DateTime PaymentDate { get; init; }
}