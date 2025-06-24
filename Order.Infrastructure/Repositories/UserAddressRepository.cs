using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Entities;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories;

public class UserAddressRepository : IUserAddressRepository
{
    private readonly OrderHistoryDbContext _dbContext;

    public UserAddressRepository(OrderHistoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<UserAddress>> GetAllAsync()
    {
        return await _dbContext.UserAddresses
            .Include(ua => ua.Customer)
            .Include(ua => ua.Address)
            .ToListAsync();
    }

    public async Task<UserAddress?> GetByIdAsync(int id)
    {
        return await _dbContext.UserAddresses
            .Include(ua => ua.Customer)
            .Include(ua => ua.Address)
            .FirstOrDefaultAsync(ua => ua.Id == id);
    }

    public async Task<UserAddress> AddAsync(UserAddress userAddress)
    {
        _dbContext.UserAddresses.Add(userAddress);
        await _dbContext.SaveChangesAsync();
        return userAddress;
    }

    public async Task UpdateAsync(UserAddress userAddress)
    {
        _dbContext.UserAddresses.Update(userAddress);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var userAddress = await _dbContext.UserAddresses.FindAsync(id);
        if (userAddress != null)
        {
            _dbContext.UserAddresses.Remove(userAddress);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<UserAddress>> GetByCustomerIdAsync(int customerId)
    {
        return await _dbContext.UserAddresses
            .Include(ua => ua.Address)
            .Where(ua => ua.Customer_Id == customerId)
            .ToListAsync();
    }

    public async Task<UserAddress?> GetDefaultAddressAsync(int customerId)
    {
        return await _dbContext.UserAddresses
            .Include(ua => ua.Address)
            .FirstOrDefaultAsync(ua => ua.Customer_Id == customerId && ua.IsDefaultAddress);
    }
}
