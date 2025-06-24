using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Repositories;

public interface IOrderHistoryRepository
{
    Task<IEnumerable<OrderHistory>> GetAllAsync();
    Task<OrderHistory?> GetByIdAsync(int id);
    Task<OrderHistory> AddAsync(OrderHistory order);
    Task UpdateAsync(OrderHistory order);
    Task DeleteAsync(int id);
}