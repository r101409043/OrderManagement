namespace Order.ApplicationCore.Entities;

public class UserAddress
{
    public int Id { get; set; }
    public int Customer_Id { get; set; }
    public int Address_Id { get; set; }
    public bool IsDefaultAddress { get; set; }

    public Customer Customer { get; set; }
    public Address Address { get; set; }
}