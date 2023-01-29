using Joyeria.Domain.Entities;

namespace Joyeria.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        Task<Product> UpdateAsync(Product productToUpdate);
        Task<Product> CreateAsync(Product productToCreate);
        Task DeleteAsync(Guid id);
    }
}
