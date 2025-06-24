using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Entities;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories;

public class ShoppingCartItemRepository : IShoppingCartItemRepository
{
    private readonly OrderHistoryDbContext _dbContext;

    public ShoppingCartItemRepository(OrderHistoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ShoppingCartItem>> GetByCartIdAsync(int cartId)
    {
        return await _dbContext.ShoppingCartItems
            .Where(i => i.Cart_Id == cartId)
            .ToListAsync();
    }

    public async Task<ShoppingCartItem?> GetByIdAsync(int id)
    {
        return await _dbContext.ShoppingCartItems.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<ShoppingCartItem> AddAsync(ShoppingCartItem item)
    {
        _dbContext.ShoppingCartItems.Add(item);
        await _dbContext.SaveChangesAsync();
        return item;
    }

    public async Task UpdateAsync(ShoppingCartItem item)
    {
        _dbContext.ShoppingCartItems.Update(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await _dbContext.ShoppingCartItems.FindAsync(id);
        if (item != null)
        {
            _dbContext.ShoppingCartItems.Remove(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}