using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Services;

public interface IOrderService
{
    Task<IEnumerable<OrderEntity>> GetOrdersByUserIdAsync(int userId);
    Task<OrderEntity> GetOrderByIdAsync(int orderId);
    Task<OrderEntity> CreateOrderAsync(OrderEntity order);
    Task UpdateOrderAsync(int orderId, OrderEntity updatedOrder);
    Task<IEnumerable<OrderEntity>> GetAllOrdersAsync();
    Task<string> GetOrderStatusAsync(int orderId);
    Task CancelOrderAsync(int orderId);
    Task MarkOrderCompletedAsync(int orderId);
}