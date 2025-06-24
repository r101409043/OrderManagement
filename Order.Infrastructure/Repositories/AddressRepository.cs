using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Entities;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly OrderHistoryDbContext _dbContext;

    public AddressRepository(OrderHistoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Address>> GetAllAsync()
    {
        return await _dbContext.Addresses.Include(a => a.UserAddresses).ToListAsync();
    }

    public async Task<Address?> GetByIdAsync(int id)
    {
        return await _dbContext.Addresses.Include(a => a.UserAddresses).FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Address> AddAsync(Address address)
    {
        _dbContext.Addresses.Add(address);
        await _dbContext.SaveChangesAsync();
        return address;
    }

    public async Task UpdateAsync(Address address)
    {
        _dbContext.Addresses.Update(address);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var address = await _dbContext.Addresses.FindAsync(id);
        if (address != null)
        {
            _dbContext.Addresses.Remove(address);
            await _dbContext.SaveChangesAsync();
        }
    }
}