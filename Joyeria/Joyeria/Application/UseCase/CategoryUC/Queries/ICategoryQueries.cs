using Joyeria.Application.UseCase.CategoryUC.Commands;

namespace Joyeria.Application.UseCase.CategoryUC.Queries
{
    public interface ICategoryQueries
    {
        Task<IEnumerable<CategoryModel>> GetCategoriesAsync();
        Task<CategoryModel> GetCategoryByIdAsync(int id);
    }
}
