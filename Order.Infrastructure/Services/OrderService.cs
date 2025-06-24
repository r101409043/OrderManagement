using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<OrderEntity>> GetOrdersByUserIdAsync(int userId)
    {
        return await _orderRepository.GetOrdersByUserIdAsync(userId);
    }

    public async Task<OrderEntity> GetOrderByIdAsync(int orderId)
    {
        return await _orderRepository.GetOrderByIdAsync(orderId);
    }

    public async Task<OrderEntity> CreateOrderAsync(OrderEntity order)
    {
        return await _orderRepository.AddOrderAsync(order);
    }

    public async Task UpdateOrderAsync(int orderId, OrderEntity updatedOrder)
    {
        await _orderRepository.UpdateOrderAsync(orderId, updatedOrder);
    }
}