using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.Infrastructure.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;
    private readonly IUserAddressRepository _userAddressRepository;

    public CustomerService(ICustomerRepository repository, IUserAddressRepository userAddressRepository)
    {
        _repository = repository;
        _userAddressRepository = userAddressRepository;
    }

    public Task<IEnumerable<Customer>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<Customer?> GetByIdAsync(int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public Task<Customer> CreateAsync(Customer customer)
    {
        return _repository.AddAsync(customer);
    }

    public Task UpdateAsync(Customer customer)
    {
        return _repository.UpdateAsync(customer);
    }

    public Task DeleteAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }

    public Task<UserAddress?> GetCustomerAddressByUserIdAsync(int userId)
    {
        return _userAddressRepository.GetDefaultAddressAsync(userId);
    }

    public Task<UserAddress> SaveCustomerAddressAsync(UserAddress address)
    {
        return _userAddressRepository.AddAsync(address);
    }
}