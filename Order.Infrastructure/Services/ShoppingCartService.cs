using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.Infrastructure.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IShoppingCartRepository _repository;

    public ShoppingCartService(IShoppingCartRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<ShoppingCart>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<ShoppingCart?> GetByIdAsync(int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public Task<ShoppingCart> CreateAsync(ShoppingCart cart)
    {
        return _repository.AddAsync(cart);
    }

    public Task UpdateAsync(ShoppingCart cart)
    {
        return _repository.UpdateAsync(cart);
    }

    public Task DeleteAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }

    public Task<ShoppingCart?> GetByCustomerIdAsync(int customerId)
    {
        return _repository.GetByCustomerIdAsync(customerId);
    }
}