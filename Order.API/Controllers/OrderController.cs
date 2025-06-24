using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    [HttpGet("GetAllOrders")]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpPost("SaveOrder")]
    public async Task<IActionResult> SaveOrder([FromBody] OrderEntity order)
    {
        var created = await orderService.CreateOrderAsync(order);
        return Ok(created);
    }

    [HttpGet("CheckOrderHistory")]
    public async Task<IActionResult> CheckOrderHistory([FromQuery] int userId)
    {
        var orders = await orderService.GetOrdersByUserIdAsync(userId);
        return Ok(orders);
    }

    [HttpGet("CheckOrderStatus")]
    public async Task<IActionResult> CheckOrderStatus([FromQuery] int orderId)
    {
        var status = await orderService.GetOrderStatusAsync(orderId);
        return Ok(new { orderId, status });
    }

    [HttpPut("CancelOrder")]
    public async Task<IActionResult> CancelOrder([FromQuery] int orderId)
    {
        await orderService.CancelOrderAsync(orderId);
        return NoContent();
    }

    [HttpPost("OrderCompleted")]
    public async Task<IActionResult> OrderCompleted([FromQuery] int orderId)
    {
        await orderService.MarkOrderCompletedAsync(orderId);
        return Ok();
    }

    [HttpPut("UpdateOrder")]
    public async Task<IActionResult> UpdateOrder([FromBody] OrderEntity updatedOrder)
    {
        await orderService.UpdateOrderAsync(updatedOrder.Id, updatedOrder);
        return NoContent();
    }
}