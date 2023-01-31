using Joyeria.Domain.Entities;

namespace Joyeria.Application.UseCase.CategoryUC.Commands
{
    public interface ICategoryCommands
    {
        Task<CategoryModel> CreateAsync(CategoryModel categoryToCreate);
        Task<CategoryModel> UpdateAsync(CategoryModel categoryToUpdate);
    }
}
