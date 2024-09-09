namespace UTB.Eshop.Domain.Entities
{
    public class Carousel : Entity<int>
    {
        public string ImageSrc { get; set; }
        public string ImageAlt { get; set; }
    }
}
