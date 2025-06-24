using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync(int pageNumber, int pageSize);
        Task<Category?> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetByParentCategoryIdAsync(int parentId);
        Task<Category> CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
    }
}