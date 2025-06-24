using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Entities;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories;

public class OrderRepository(OrderDbContext dbContext) : IOrderRepository
{
    public async Task<IEnumerable<OrderEntity>> GetOrdersByUserIdAsync(int userId)
    {
        return await dbContext.Orders
            .Include(o => o.OrderItems)
            .Where(o => o.UserId == userId)
            .ToListAsync();
    }

    public async Task<OrderEntity> GetOrderByIdAsync(int orderId)
    {
        return (await dbContext.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.Id == orderId))!;
    }

    public async Task<OrderEntity> AddOrderAsync(OrderEntity order)
    {
        dbContext.Orders.Add(order);
        await dbContext.SaveChangesAsync();
        return order;
    }

    public async Task DeleteOrderAsync(int orderId)
    {
        var order = await dbContext.Orders.FindAsync(orderId);
        if (order != null)
        {
            dbContext.Orders.Remove(order);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task UpdateOrderAsync(int orderId, OrderEntity updatedOrder)
    {
        var existing = await dbContext.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.Id == orderId);

        if (existing != null)
        {
            existing.UserId = updatedOrder.UserId;
            existing.TotalPrice = updatedOrder.TotalPrice;
            existing.OrderDateTime = updatedOrder.OrderDateTime;
            existing.OrderItems = updatedOrder.OrderItems;

            await dbContext.SaveChangesAsync();
        }
    }
}