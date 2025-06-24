using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Services;

public interface IOrderService
{
    Task<IEnumerable<OrderEntity>> GetOrdersByUserIdAsync(int userId);
    Task<OrderEntity> GetOrderByIdAsync(int orderId);
    Task<OrderEntity> CreateOrderAsync(OrderEntity order);
    Task UpdateOrderAsync(int orderId, OrderEntity updatedOrder);
}