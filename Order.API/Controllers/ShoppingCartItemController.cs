using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoppingCartItemController(IShoppingCartItemService itemService) : ControllerBase
{
    [HttpGet("cart/{cartId:int}")]
    public async Task<IActionResult> GetByCartId(int cartId)
    {
        var items = await itemService.GetByCartIdAsync(cartId);
        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await itemService.GetByIdAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ShoppingCartItem item)
    {
        var createdItem = await itemService.CreateAsync(item);
        return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ShoppingCartItem item)
    {
        if (id != item.Id)
        {
            return BadRequest();
        }

        await itemService.UpdateAsync(item);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await itemService.DeleteAsync(id);
        return NoContent();
    }
}