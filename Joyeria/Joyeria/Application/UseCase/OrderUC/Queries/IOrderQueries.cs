using Joyeria.Application.UseCase.OrderUC.Commands;

namespace Joyeria.Application.UseCase.OrderUC.Queries
{
    public interface IOrderQueries
    {
        Task<IEnumerable<OrderModel>> GetOrdersAsync();
        Task<OrderModel> GetOrdeByIdAsync(Guid id);
        Task<IEnumerable<ReporteVentasModel>> GetResumen();

    }
}
