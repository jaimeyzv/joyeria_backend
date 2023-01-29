using Joyeria.Application.Interfaces;
using Joyeria.Application.Interfaces.Services;
using Joyeria.Domain.Entities;

namespace Joyeria.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public async Task<Category> CreateAsync(Category categoryToCreate)
        {
            await _unitOfWork.Categories.CreateAsync(categoryToCreate);
            await _unitOfWork.SaveChangesAsync();

            return categoryToCreate;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _unitOfWork.Categories.GetCategoriesAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _unitOfWork.Categories.GetCategoryByIdAsync(id);
        }

        public async Task<Category> UpdateAsync(Category categoryToUpdate)
        {
            await _unitOfWork.Categories.UpdateAsync(categoryToUpdate);
            await _unitOfWork.SaveChangesAsync();
            return categoryToUpdate;
        }
    }
}
