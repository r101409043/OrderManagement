using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController(IAddressService addressService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var addresses = await addressService.GetAllAsync();
        return Ok(addresses);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var address = await addressService.GetByIdAsync(id);
        if (address == null) return NotFound();
        return Ok(address);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Address address)
    {
        var created = await addressService.CreateAsync(address);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Address address)
    {
        if (id != address.Id) return BadRequest("ID mismatch");
        await addressService.UpdateAsync(address);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await addressService.DeleteAsync(id);
        return NoContent();
    }
}