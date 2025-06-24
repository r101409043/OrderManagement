using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.Infrastructure.Services;

public class ShoppingCartItemService : IShoppingCartItemService
{
    private readonly IShoppingCartItemRepository _repository;

    public ShoppingCartItemService(IShoppingCartItemRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<ShoppingCartItem>> GetByCartIdAsync(int cartId)
    {
        return _repository.GetByCartIdAsync(cartId);
    }

    public Task<ShoppingCartItem?> GetByIdAsync(int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public Task<ShoppingCartItem> CreateAsync(ShoppingCartItem item)
    {
        return _repository.AddAsync(item);
    }

    public Task UpdateAsync(ShoppingCartItem item)
    {
        return _repository.UpdateAsync(item);
    }

    public Task DeleteAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }
}