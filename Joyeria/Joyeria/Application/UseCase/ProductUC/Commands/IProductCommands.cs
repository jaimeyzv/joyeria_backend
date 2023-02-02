using Joyeria.Domain.Entities;

namespace Joyeria.Application.UseCase.ProductUC.Commands
{
    public interface IProductCommands
    {
       
        Task<ProductModel> UpdateAsync(ProductModel productToUpdate);
        Task<ProductModel> CreateAsync(ProductModel productToCreate);
        Task DeleteAsync(Guid id);
    }
}
