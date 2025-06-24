using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Category>> GetAllAsync(int pageNumber, int pageSize)
        {
            return _repository.GetAllAsync(pageNumber, pageSize);
        }

        public Task<Category?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<IEnumerable<Category>> GetByParentCategoryIdAsync(int parentId)
        {
            return _repository.GetByParentCategoryIdAsync(parentId);
        }

        public Task<Category> CreateAsync(Category category)
        {
            return _repository.AddAsync(category);
        }

        public Task UpdateAsync(Category category)
        {
            return _repository.UpdateAsync(category);
        }

        public Task DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}