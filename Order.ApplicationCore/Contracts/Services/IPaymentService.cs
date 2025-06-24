using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Services;

public interface IPaymentService
{
    Task<IEnumerable<Payment>> GetPaymentsByCustomerIdAsync(int customerId);
    Task<Payment> AddPaymentAsync(Payment payment);
    Task UpdatePaymentAsync(Payment payment);
    Task DeletePaymentAsync(int id);
}