using Joyeria.Domain.Entities.Report;
using Joyeria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joyeria.Application.UseCase.OrderUC.Queries;

namespace Joyeria.Application.UseCase.OrderUC.Commands
{
    public interface IOrderCommands
    {
        Task<OrderModel> UpdateAsync(OrderModel orderToUpdate);
        Task<OrderModel> CreateAsync(OrderModel orderToCreate);
        Task DeleteAsync(Guid id);
    }
}
