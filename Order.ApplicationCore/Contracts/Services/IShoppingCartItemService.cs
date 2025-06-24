using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Services;

public interface IShoppingCartItemService
{
    Task<IEnumerable<ShoppingCartItem>> GetByCartIdAsync(int cartId);
    Task<ShoppingCartItem?> GetByIdAsync(int id);
    Task<ShoppingCartItem> CreateAsync(ShoppingCartItem item);
    Task UpdateAsync(ShoppingCartItem item);
    Task DeleteAsync(int id);
}