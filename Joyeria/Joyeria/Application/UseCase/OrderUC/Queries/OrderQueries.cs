using AutoMapper;
using Joyeria.Application.Interfaces;
using Joyeria.Application.UseCase.OrderUC.Commands;

namespace Joyeria.Application.UseCase.OrderUC.Queries
{
    public class OrderQueries : IOrderQueries
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderQueries(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OrderModel> GetOrdeByIdAsync(Guid id)
        {
            var domain = await _unitOfWork.Orders.GetOrdeByIdAsync(id);
            var model = _mapper.Map<OrderModel>(domain);
            return model;
        }

        public async Task<IEnumerable<OrderModel>> GetOrdersAsync()
        {
            
            var domain = await _unitOfWork.Orders.GetOrdersAsync();
            var model = _mapper.Map<IEnumerable<OrderModel>>(domain);
            return model;
        }

        public async Task<IEnumerable<ReporteVentasModel>> GetResumen()
        {
            var domain = await _unitOfWork.Orders.GetResumen();
            var model = _mapper.Map<IEnumerable<ReporteVentasModel>>(domain);
            return model;
        }
    }
}
