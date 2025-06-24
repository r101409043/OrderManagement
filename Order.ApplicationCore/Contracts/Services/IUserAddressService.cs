using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Services;

public interface IUserAddressService
{
    Task<IEnumerable<UserAddress>> GetAllAsync();
    Task<UserAddress?> GetByIdAsync(int id);
    Task<UserAddress> CreateAsync(UserAddress userAddress);
    Task UpdateAsync(UserAddress userAddress);
    Task DeleteAsync(int id);

    Task<IEnumerable<UserAddress>> GetByCustomerIdAsync(int customerId);
    Task<UserAddress?> GetDefaultAddressAsync(int customerId);
}