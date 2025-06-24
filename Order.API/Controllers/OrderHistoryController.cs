using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderHistoryController(IOrderHistoryService orderService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await orderService.GetAllAsync();
        return Ok(orders);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrderHistory order)
    {
        var created = await orderService.CreateAsync(order);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
    
    [HttpGet("customer/{customerId:int}")]
    public async Task<IActionResult> GetByCustomerId(int customerId)
    {
        var orders = (await orderService.GetAllAsync())
            .Where(o => o.CustomerId == customerId);
        return Ok(orders);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await orderService.DeleteAsync(id);
        return NoContent();
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] OrderHistory order)
    {
        if (id != order.Id)
            return BadRequest("Order ID mismatch.");

        await orderService.UpdateAsync(order);
        return NoContent();
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await orderService.GetByIdAsync(id);
        if (order == null) return NotFound();
        return Ok(order);
    }
}