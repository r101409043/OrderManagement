using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.Infrastructure.Services;

public class OrderHistoryService : IOrderHistoryService
{
    private readonly IOrderHistoryRepository _repository;

    public OrderHistoryService(IOrderHistoryRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<OrderHistory>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<OrderHistory?> GetByIdAsync(int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public Task<OrderHistory> CreateAsync(OrderHistory order)
    {
        return _repository.AddAsync(order);
    }

    public Task UpdateAsync(OrderHistory order)
    {
        return _repository.UpdateAsync(order);
    }

    public Task DeleteAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }
}