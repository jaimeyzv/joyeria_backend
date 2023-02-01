using Joyeria.Application.Interfaces;

namespace Joyeria.Application.UseCase.OrderUC.Commands
{
    public class OrderCommands : IOrderCommands
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderCommands(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<OrderModel> CreateAsync(OrderModel orderToCreate)
        {
            throw new NotImplementedException();
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
