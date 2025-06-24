using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Entities;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories;

public class OrderDetailRepository : IOrderDetailRepository
{
    private readonly OrderHistoryDbContext _dbContext;

    public OrderDetailRepository(OrderHistoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<OrderDetail>> GetByOrderIdAsync(int orderId)
    {
        return await _dbContext.OrderDetails
            .Where(d => d.Order_Id == orderId)
            .ToListAsync();
    }

    public async Task<OrderDetail?> GetByIdAsync(int id)
    {
        return await _dbContext.OrderDetails.FindAsync(id);
    }

    public async Task<OrderDetail> AddAsync(OrderDetail detail)
    {
        _dbContext.OrderDetails.Add(detail);
        await _dbContext.SaveChangesAsync();
        return detail;
    }

    public async Task UpdateAsync(OrderDetail detail)
    {
        _dbContext.OrderDetails.Update(detail);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var detail = await _dbContext.OrderDetails.FindAsync(id);
        if (detail != null)
        {
            _dbContext.OrderDetails.Remove(detail);
            await _dbContext.SaveChangesAsync();
        }
    }
}