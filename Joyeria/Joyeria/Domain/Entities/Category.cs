using System.ComponentModel.DataAnnotations.Schema;

namespace Joyeria.Domain.Entities
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
