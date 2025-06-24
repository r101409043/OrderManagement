using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Repositories;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> GetPaymentsByCustomerIdAsync(int customerId);
    Task<Payment> AddPaymentAsync(Payment payment);
    Task UpdatePaymentAsync(Payment payment);
    Task DeletePaymentAsync(int id);
}