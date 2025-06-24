using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.Infrastructure.Services;

public class PaymentService(IPaymentRepository repository) : IPaymentService
{
    public Task<IEnumerable<Payment>> GetPaymentsByCustomerIdAsync(int customerId)
    {
        return repository.GetPaymentsByCustomerIdAsync(customerId);
    }

    public Task<Payment> AddPaymentAsync(Payment payment)
    {
        return repository.AddPaymentAsync(payment);
    }

    public Task UpdatePaymentAsync(Payment payment)
    {
        return repository.UpdatePaymentAsync(payment);
    }

    public Task DeletePaymentAsync(int id)
    {
        return repository.DeletePaymentAsync(id);
    }
}