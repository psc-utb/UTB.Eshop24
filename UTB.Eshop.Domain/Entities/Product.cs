using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.Eshop.Domain.Entities
{
    [Table(nameof(Product))]
    public class Product : Entity<int>
    {
        [Required]
        [StringLength(70)]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? ImageSrc { get; set; }
    }
}
