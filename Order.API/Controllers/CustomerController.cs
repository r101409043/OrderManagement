using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await customerService.GetAllAsync();
        return Ok(customers);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var customer = await customerService.GetByIdAsync(id);
        if (customer == null) return NotFound();
        return Ok(customer);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Customer customer)
    {
        var created = await customerService.CreateAsync(customer);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Customer customer)
    {
        if (id != customer.Id) return BadRequest("ID mismatch");
        await customerService.UpdateAsync(customer);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await customerService.DeleteAsync(id);
        return NoContent();
    }
    
    [HttpGet("GetCustomerAddressByUserId")]
    public async Task<IActionResult> GetCustomerAddressByUserId([FromQuery] int userId)
    {
        var addresses = await customerService.GetCustomerAddressByUserIdAsync(userId);
        return Ok(addresses);
    }

    [HttpPost("SaveCustomerAddress")]
    public async Task<IActionResult> SaveCustomerAddress([FromBody] UserAddress address)
    {
        var created = await customerService.SaveCustomerAddressAsync(address);
        return Ok(created);
    }
    
}