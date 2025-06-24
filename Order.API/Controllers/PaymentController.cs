using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController(IPaymentService paymentService) : ControllerBase
{
    [HttpGet("GetPaymentByCustomerId")]
    public async Task<IActionResult> GetPayments(int customerId)
    {
        var list = await paymentService.GetPaymentsByCustomerIdAsync(customerId);
        return Ok(list);
    }

    [HttpPost("SavePayment")]
    public async Task<IActionResult> Save([FromBody] Payment payment)
    {
        var saved = await paymentService.AddPaymentAsync(payment);
        return Ok(saved);
    }

    [HttpPut("UpdatePayment")]
    public async Task<IActionResult> Update([FromBody] Payment payment)
    {
        await paymentService.UpdatePaymentAsync(payment);
        return NoContent();
    }

    [HttpDelete("DeletePayment")]
    public async Task<IActionResult> Delete(int id)
    {
        await paymentService.DeletePaymentAsync(id);
        return NoContent();
    }
}