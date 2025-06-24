using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync(int pageNumber, int pageSize);
        Task<Category?> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetByParentCategoryIdAsync(int parentId);
        Task<Category> AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
    }
}