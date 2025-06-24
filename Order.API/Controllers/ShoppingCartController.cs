using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoppingCartController(IShoppingCartService cartService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var carts = await cartService.GetAllAsync();
        return Ok(carts);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var cart = await cartService.GetByIdAsync(id);
        if (cart == null)
        {
            return NotFound();
        }
        return Ok(cart);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ShoppingCart cart)
    {
        var createdCart = await cartService.CreateAsync(cart);
        return CreatedAtAction(nameof(GetById), new { id = createdCart.Id }, createdCart);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ShoppingCart cart)
    {
        if (id != cart.Id)
        {
            return BadRequest();
        }

        await cartService.UpdateAsync(cart);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await cartService.DeleteAsync(id);
        return NoContent();
    }
    
    [HttpGet("GetShoppingCartByCustomerId")]
    public async Task<IActionResult> GetShoppingCartByCustomerId([FromQuery] int customerId)
    {
        var cart = await cartService.GetByCustomerIdAsync(customerId);
        return Ok(cart);
    }

    [HttpPost("SaveShoppingCart")]
    public async Task<IActionResult> SaveShoppingCart([FromBody] ShoppingCart cart)
    {
        var created = await cartService.CreateAsync(cart);
        return Ok(created);
    }

    [HttpDelete("DeleteShoppingCart")]
    public async Task<IActionResult> DeleteShoppingCart([FromQuery] int id)
    {
        await cartService.DeleteAsync(id);
        return NoContent();
    }

}