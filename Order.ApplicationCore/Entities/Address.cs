namespace Order.ApplicationCore.Entities;

public class Address
{
    public int Id { get; set; }
    public string Street1 { get; set; }
    public string Street2 { get; set; }
    public string City { get; set; }
    public string Zipcode { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    public ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
}