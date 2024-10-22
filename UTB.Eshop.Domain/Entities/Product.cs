using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Eshop.Domain.Validations;
using Microsoft.AspNetCore.Http;

namespace UTB.Eshop.Domain.Entities
{
    [Table(nameof(Product))]
    public class Product : Entity<int>
    {
        [Required]
        [StringLength(70)]
        public string? Name { get; set; }
        [FirstLetterCapitalizedCZ]
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? ImageSrc { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }
    }
}
