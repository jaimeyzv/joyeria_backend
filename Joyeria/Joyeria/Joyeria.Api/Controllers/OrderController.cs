using AutoMapper;
using Joyeria.Application.UseCase.OrderUC.Commands;
using Joyeria.Application.UseCase.OrderUC.Queries;
using Joyeria.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Joyeria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController: ControllerBase
    {
        private readonly IOrderCommands _orderCommands;
        private readonly IOrderQueries _orderQueries;
        private readonly IMapper _mapper;

        public OrderController(IOrderCommands orderCommands,
            IOrderQueries orderQueries, IMapper mapper)
        {
            _orderCommands = orderCommands;
            _orderQueries = orderQueries;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetOrder()
        {
            try
            {
                var orders = await _orderQueries.GetOrdersAsync();
                foreach (var item in orders)
                {
                    Console.WriteLine(item.detalle);
                }
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



        [HttpGet("resumen")]
        public async Task<IActionResult> Resumen()
        {
            try
            {
                var orders = await _orderQueries.GetResumen();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetOrderById([FromRoute] Guid id)
        {
            try
            {
                var order = await _orderQueries.GetOrdeByIdAsync(id);
                if (order == null) return BadRequest($"Order con id {id} no existe");

                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderVM order)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest($"Payload order no es valido");


                var orderToCreate = new OrderModel()
                {
                    Date = order.Date,
                    UserId = order.UserId,
                    StatusId = order.StatusId,
                    Total = order.Total,
                    detalle = new List<OrderItemModel>()
                    //CategoryId = proorderduct.CategoryId,
                };
                foreach (var itemCrear in order.detalle)
                {
                    orderToCreate.detalle.Add(new OrderItemModel
                    {
                        Amount = itemCrear.Amount,
                        Price = itemCrear.Price,
                        TotalAmount = itemCrear.TotalAmount,

                        ProductId = itemCrear.ProductId

                    });
                }

                var orderCreated = _orderCommands.CreateAsync(orderToCreate);

                return Ok(orderCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
