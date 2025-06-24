using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Repositories;

public interface IOrderDetailRepository
{
    Task<IEnumerable<OrderDetail>> GetByOrderIdAsync(int orderId);
    Task<OrderDetail?> GetByIdAsync(int id);
    Task<OrderDetail> AddAsync(OrderDetail detail);
    Task UpdateAsync(OrderDetail detail);
    Task DeleteAsync(int id);
}