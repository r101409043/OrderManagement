using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserAddressController(IUserAddressService userAddressService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userAddresses = await userAddressService.GetAllAsync();
        return Ok(userAddresses);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var userAddress = await userAddressService.GetByIdAsync(id);
        if (userAddress == null) return NotFound();
        return Ok(userAddress);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserAddress userAddress)
    {
        var created = await userAddressService.CreateAsync(userAddress);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UserAddress userAddress)
    {
        if (id != userAddress.Id) return BadRequest("ID mismatch");
        await userAddressService.UpdateAsync(userAddress);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await userAddressService.DeleteAsync(id);
        return NoContent();
    }

    [HttpGet("customer/{customerId:int}")]
    public async Task<IActionResult> GetByCustomerId(int customerId)
    {
        var list = await userAddressService.GetByCustomerIdAsync(customerId);
        return Ok(list);
    }

    [HttpGet("customer/{customerId:int}/default")]
    public async Task<IActionResult> GetDefault(int customerId)
    {
        var result = await userAddressService.GetDefaultAddressAsync(customerId);
        if (result == null) return NotFound();
        return Ok(result);
    }
}
