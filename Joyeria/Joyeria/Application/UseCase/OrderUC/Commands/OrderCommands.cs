using AutoMapper;
using Joyeria.Application.Interfaces;
using Joyeria.Domain.Entities;

namespace Joyeria.Application.UseCase.OrderUC.Commands
{
    public class OrderCommands : IOrderCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OrderModel> CreateAsync(OrderModel orderToCreate)
        {
            var domain = _mapper.Map<Order>(orderToCreate);
            await _unitOfWork.Orders.CreateAsync(domain);
            await _unitOfWork.SaveChangesAsync();
            return orderToCreate;
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderModel> UpdateAsync(OrderModel orderToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
