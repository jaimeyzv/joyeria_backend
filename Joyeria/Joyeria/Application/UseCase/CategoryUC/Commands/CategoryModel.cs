using Joyeria.Domain.Entities;

namespace Joyeria.Application.UseCase.CategoryUC.Commands
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
