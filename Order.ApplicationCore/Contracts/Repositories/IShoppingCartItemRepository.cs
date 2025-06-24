using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Repositories;

public interface IShoppingCartItemRepository
{
    Task<IEnumerable<ShoppingCartItem>> GetByCartIdAsync(int cartId);
    Task<ShoppingCartItem?> GetByIdAsync(int id);
    Task<ShoppingCartItem> AddAsync(ShoppingCartItem item);
    Task UpdateAsync(ShoppingCartItem item);
    Task DeleteAsync(int id);
}