using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<OrderEntity>> GetOrdersByUserIdAsync(int userId);
    Task<OrderEntity> GetOrderByIdAsync(int orderId);
    Task<OrderEntity> AddOrderAsync(OrderEntity order);
    Task DeleteOrderAsync(int orderId);
    Task UpdateOrderAsync(int orderId, OrderEntity updatedOrder);
}