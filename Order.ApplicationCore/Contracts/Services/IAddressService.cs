using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Services;

public interface IAddressService
{
    Task<IEnumerable<Address>> GetAllAsync();
    Task<Address?> GetByIdAsync(int id);
    Task<Address> CreateAsync(Address address);
    Task UpdateAsync(Address address);
    Task DeleteAsync(int id);
}