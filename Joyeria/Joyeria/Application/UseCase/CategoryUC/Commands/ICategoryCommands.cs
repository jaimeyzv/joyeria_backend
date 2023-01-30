using Joyeria.Domain.Entities;

namespace Joyeria.Application.UseCase.CategoryUC.Commands
{
    public interface ICategoryCommands
    {
        Task<CategoryModel> CreateAsync(Category categoryToCreate);
        Task<CategoryModel> UpdateAsync(Category categoryToUpdate);
    }
}
