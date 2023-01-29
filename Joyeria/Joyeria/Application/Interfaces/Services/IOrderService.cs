using Joyeria.Domain.Entities;
using Joyeria.Domain.Entities.Report;

namespace Joyeria.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrdeByIdAsync(Guid id);
        Task<Order> UpdateAsync(Order orderToUpdate);
        Task<Order> CreateAsync(Order orderToCreate);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<ReporteVentas>> GetResumen();
    }
}


