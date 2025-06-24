using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.Infrastructure.Services;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{
    public async Task<IEnumerable<OrderEntity>> GetOrdersByUserIdAsync(int userId)
    {
        return await orderRepository.GetOrdersByUserIdAsync(userId);
    }

    public async Task<OrderEntity> GetOrderByIdAsync(int orderId)
    {
        return await orderRepository.GetOrderByIdAsync(orderId);
    }

    public async Task<OrderEntity> CreateOrderAsync(OrderEntity order)
    {
        return await orderRepository.AddOrderAsync(order);
    }

    public async Task UpdateOrderAsync(int orderId, OrderEntity updatedOrder)
    {
        await orderRepository.UpdateOrderAsync(orderId, updatedOrder);
    }
    
    public async Task<IEnumerable<OrderEntity>> GetAllOrdersAsync()
    {
        return await orderRepository.GetAllOrdersAsync();
    }

    public async Task<string> GetOrderStatusAsync(int orderId)
    {
        var order = await orderRepository.GetOrderByIdAsync(orderId);
        return order.Status;
    }

    public async Task CancelOrderAsync(int orderId)
    {
        var order = await orderRepository.GetOrderByIdAsync(orderId);
        order.Status = "Cancelled";
        await orderRepository.UpdateOrderAsync(orderId, order);
    }

    public async Task MarkOrderCompletedAsync(int orderId)
    {
        var order = await orderRepository.GetOrderByIdAsync(orderId);
        order.Status = "Completed";
        await orderRepository.UpdateOrderAsync(orderId, order);
    }

}