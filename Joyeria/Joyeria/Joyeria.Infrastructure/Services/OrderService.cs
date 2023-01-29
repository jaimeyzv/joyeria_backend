﻿using Joyeria.Application.Interfaces;
using Joyeria.Application.Interfaces.Services;
using Joyeria.Domain.Entities;
using Joyeria.Domain.Entities.Report;

namespace Joyeria.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Order> CreateAsync(Order orderToCreate)
        {
            await _unitOfWork.Orders.CreateAsync(orderToCreate);
            await _unitOfWork.SaveChangesAsync();

            return orderToCreate;
        }

        Task IOrderService.DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrdeByIdAsync(Guid id)
        {
            return await _unitOfWork.Orders.GetOrdeByIdAsync(id);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _unitOfWork.Orders.GetOrdersAsync();
        }

        Task<Order> IOrderService.UpdateAsync(Order orderToUpdate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReporteVentas>> GetResumen()
        {

            return await _unitOfWork.Orders.GetResumen();
        }
    }
}

