using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joyeria.Application.UseCase.ProductUC.Commands;

namespace Joyeria.Application.UseCase.ProductUC.Queries
{
    public interface IProductQueries
    {
        Task<IEnumerable<ProductModel>> GetProductsAsync();
        Task<ProductModel> GetProductByIdAsync(Guid id);
    }
}
