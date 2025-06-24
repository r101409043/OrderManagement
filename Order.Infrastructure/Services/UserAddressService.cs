using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.Infrastructure.Services;

public class UserAddressService : IUserAddressService
{
    private readonly IUserAddressRepository _repository;

    public UserAddressService(IUserAddressRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<UserAddress>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<UserAddress?> GetByIdAsync(int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public Task<UserAddress> CreateAsync(UserAddress userAddress)
    {
        return _repository.AddAsync(userAddress);
    }

    public Task UpdateAsync(UserAddress userAddress)
    {
        return _repository.UpdateAsync(userAddress);
    }

    public Task DeleteAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }

    public Task<IEnumerable<UserAddress>> GetByCustomerIdAsync(int customerId)
    {
        return _repository.GetByCustomerIdAsync(customerId);
    }

    public Task<UserAddress?> GetDefaultAddressAsync(int customerId)
    {
        return _repository.GetDefaultAddressAsync(customerId);
    }
}