using Joyeria.Domain.Entities;

namespace Joyeria.Application.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> CreateAsync(Category categoryToCreate);
        Task<Category> UpdateAsync(Category categoryToUpdate);
    }
}
