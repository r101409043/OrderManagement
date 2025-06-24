using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Services;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(int id);
    Task<Customer> CreateAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(int id);
    Task<UserAddress?> GetCustomerAddressByUserIdAsync(int userId);
    Task<UserAddress> SaveCustomerAddressAsync(UserAddress address);
}