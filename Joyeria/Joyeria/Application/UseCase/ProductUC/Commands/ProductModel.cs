using Joyeria.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joyeria.Application.UseCase.ProductUC.Commands
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string ?Name { get; set; }
        public string ?Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string ?Image { get; set; }

        [Column("Category_id")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
