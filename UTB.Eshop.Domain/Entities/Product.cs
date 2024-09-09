using System.ComponentModel.DataAnnotations;

namespace UTB.Eshop.Domain.Entities
{
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
