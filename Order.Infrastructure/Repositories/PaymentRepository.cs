using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Entities;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories;

public class PaymentRepository(OrderHistoryDbContext dbContext) : IPaymentRepository
{
    public async Task<IEnumerable<Payment>> GetPaymentsByCustomerIdAsync(int customerId)
    {
        return await dbContext.Payments
            .Where(p => p.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<Payment> AddPaymentAsync(Payment payment)
    {
        dbContext.Payments.Add(payment);
        await dbContext.SaveChangesAsync();
        return payment;
    }

    public async Task UpdatePaymentAsync(Payment payment)
    {
        dbContext.Payments.Update(payment);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeletePaymentAsync(int id)
    {
        var payment = await dbContext.Payments.FindAsync(id);
        if (payment != null)
        {
            dbContext.Payments.Remove(payment);
            await dbContext.SaveChangesAsync();
        }
    }
}