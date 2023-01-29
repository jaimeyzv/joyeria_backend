using Joyeria.Domain.Entities;

namespace Joyeria.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        Task<Product> UpdateAsync(Product productToUpdate);
        Task<Product> CreateAsync(Product productToCreate);
        Task DeleteAsync(Guid id);
    }
}
