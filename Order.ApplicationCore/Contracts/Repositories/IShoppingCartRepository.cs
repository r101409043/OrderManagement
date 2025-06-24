using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Repositories;

public interface IShoppingCartRepository
{
    Task<IEnumerable<ShoppingCart>> GetAllAsync();
    Task<ShoppingCart?> GetByIdAsync(int id);
    Task<ShoppingCart> AddAsync(ShoppingCart cart);
    Task UpdateAsync(ShoppingCart cart);
    Task DeleteAsync(int id);
    Task<ShoppingCart?> GetByCustomerIdAsync(int customerId);
}