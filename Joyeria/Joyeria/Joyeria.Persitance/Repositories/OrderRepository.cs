using Joyeria.Application.Interfaces.Repositories;
using Joyeria.Domain.Entities;
using Joyeria.Domain.Entities.Report;
using Joyeria.Persitance.Shared;
using Microsoft.EntityFrameworkCore;

namespace Joyeria.Persitance.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly JoyeriaDbContext _dbContext;

        public OrderRepository(JoyeriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Order> CreateAsync(Order orderToCreate)
        {
            await _dbContext.Orders.AddAsync(orderToCreate);
            return orderToCreate;
        }

        public async Task DeleteAsync(Guid id)
        {
            var order = await _dbContext.Orders.FindAsync(id);
            _dbContext.Orders.Remove(order);
            
        }

        public async Task<Order> GetOrdeByIdAsync(Guid id)
        {
            //var order = await _dbContext.Orders.FindAsync(id);
            //return order;
            return await _dbContext.Orders.Include(det => det.detalle).Where(sql => sql.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await this._dbContext.Orders.Include(det => det.detalle).ToListAsync();
            // return await this._dbContext.Orders.Include<OrderItem>
        }

        public async Task<IEnumerable<ReporteVentas>> GetResumen()
        {
            return await(from cab in this._dbContext.Orders
                         join usuario in this._dbContext.Users
                         on cab.UserId equals usuario.Id
                         group new { cab, usuario } by new { mes = cab.Date.Month, name = usuario.Name, usuario.LastName } into gr
                         select new ReporteVentas
                         {
                             cliente = gr.Key.name + "- " + gr.Key.LastName,
                             mes = gr.Key.mes.ToString()
                         ,
                             total = gr.Sum(ord => ord.cab.Total)
                         }).ToListAsync();
        }

        public Task<Order> UpdateAsync(Order orderToUpdate)
        {
            throw new NotImplementedException();
        }

        private string obtenerMes(int idMes)
        {
            switch (idMes)
            {
                case 1:
                    return "Enero";

                default:
                    break;
            }
            return "";
        }
    }
}
