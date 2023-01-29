using Joyeria.Domain.Entities;

namespace Joyeria.Application.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> CreateAsync(Category categoryToCreate);
        Task<Category> UpdateAsync(Category categoryToUpdate);
    }
}
