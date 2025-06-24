using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Entities;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories;

public class OrderHistoryRepository : IOrderHistoryRepository
{
    private readonly OrderHistoryDbContext _dbContext;

    public OrderHistoryRepository(OrderHistoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<OrderHistory>> GetAllAsync()
    {
        return await _dbContext.Orders.Include(o => o.OrderDetails).ToListAsync();
    }

    public async Task<OrderHistory?> GetByIdAsync(int id)
    {
        return await _dbContext.Orders.Include(o => o.OrderDetails).FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<OrderHistory> AddAsync(OrderHistory order)
    {
        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();
        return order;
    }

    public async Task UpdateAsync(OrderHistory order)
    {
        _dbContext.Orders.Update(order);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var order = await _dbContext.Orders.FindAsync(id);
        if (order != null)
        {
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
        }
    }
}