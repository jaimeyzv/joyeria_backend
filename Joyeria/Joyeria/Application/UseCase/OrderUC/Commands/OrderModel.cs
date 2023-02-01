namespace Joyeria.Application.UseCase.OrderUC.Commands
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public decimal Total { get; set; }
    }
}
