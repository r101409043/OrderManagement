using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.Infrastructure.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _repository;

    public AddressService(IAddressRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Address>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<Address?> GetByIdAsync(int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public Task<Address> CreateAsync(Address address)
    {
        return _repository.AddAsync(address);
    }

    public Task UpdateAsync(Address address)
    {
        return _repository.UpdateAsync(address);
    }

    public Task DeleteAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }
}