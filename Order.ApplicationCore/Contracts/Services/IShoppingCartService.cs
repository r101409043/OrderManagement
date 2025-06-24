using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Services;

public interface IShoppingCartService
{
    Task<IEnumerable<ShoppingCart>> GetAllAsync();
    Task<ShoppingCart?> GetByIdAsync(int id);
    Task<ShoppingCart> CreateAsync(ShoppingCart cart);
    Task UpdateAsync(ShoppingCart cart);
    Task DeleteAsync(int id);
    Task<ShoppingCart?> GetByCustomerIdAsync(int customerId);
}