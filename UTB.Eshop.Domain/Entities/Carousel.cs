using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.Eshop.Domain.Entities
{
    [Table(nameof(Carousel))]
    public class Carousel : Entity<int>
    {
        public string ImageSrc { get; set; }
        public string ImageAlt { get; set; }
    }
}
