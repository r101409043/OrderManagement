using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Entities;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly OrderHistoryDbContext _dbContext;

    public ShoppingCartRepository(OrderHistoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ShoppingCart>> GetAllAsync()
    {
        return await _dbContext.ShoppingCarts.Include(c => c.Items).ToListAsync();
    }

    public async Task<ShoppingCart?> GetByIdAsync(int id)
    {
        return await _dbContext.ShoppingCarts.Include(c => c.Items).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<ShoppingCart> AddAsync(ShoppingCart cart)
    {
        _dbContext.ShoppingCarts.Add(cart);
        await _dbContext.SaveChangesAsync();
        return cart;
    }

    public async Task UpdateAsync(ShoppingCart cart)
    {
        _dbContext.ShoppingCarts.Update(cart);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var cart = await _dbContext.ShoppingCarts.FindAsync(id);
        if (cart != null)
        {
            _dbContext.ShoppingCarts.Remove(cart);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<ShoppingCart?> GetByCustomerIdAsync(int customerId)
    {
        return await _dbContext.ShoppingCarts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);
    }
}