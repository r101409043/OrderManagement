using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    [HttpGet("user/{userId:int}")]
    public async Task<IActionResult> GetOrdersByUserId(int userId)
    {
        var orders = await orderService.GetOrdersByUserIdAsync(userId);
        return Ok(orders);
    }

    [HttpGet("{orderId:int}")]
    public async Task<IActionResult> GetOrderById(int orderId)
    {
        var order = await orderService.GetOrderByIdAsync(orderId);
        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderEntity order)
    {
        var created = await orderService.CreateOrderAsync(order);
        return CreatedAtAction(nameof(GetOrderById), new { orderId = created.Id }, created);
    }

    [HttpPut("{orderId:int}")]
    public async Task<IActionResult> UpdateOrder(int orderId, [FromBody] OrderEntity updatedOrder)
    {
        await orderService.UpdateOrderAsync(orderId, updatedOrder);
        return NoContent();
    }
}