using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joyeria.Application.UseCase.OrderUC.Commands
{
    public  class OrderItemModel
    {
        //public Guid Id { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid ProductId { get; set; }
        //public Guid OrderId { get; set; }
    }
}
