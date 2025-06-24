using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Services;

public interface IOrderHistoryService
{
    Task<IEnumerable<OrderHistory>> GetAllAsync();
    Task<OrderHistory?> GetByIdAsync(int id);
    Task<OrderHistory> CreateAsync(OrderHistory order);
    Task UpdateAsync(OrderHistory order);
    Task DeleteAsync(int id);
}