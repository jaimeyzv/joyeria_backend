namespace Joyeria.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }

    }
}