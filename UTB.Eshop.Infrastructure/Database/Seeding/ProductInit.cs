using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Infrastructure.Database.Seeding
{
    internal class ProductInit
    {
        public IList<Product> GetProductsFood3()
        {
            IList<Product> products = new List<Product>();

            products.Add(new Product
            {
                Id = 1,
                Name = "Rohlík",
                Description = "nejlepší rohlík na světě",
                Price = 2,
                ImageSrc = "/img/products/produkty-01.jpg"
            });
            products.Add(new Product
            {
                Id = 2,
                Name = "Chleba",
                Description = "nejlepší chleba v galaxii",
                Price = 50,
                ImageSrc = "/img/products/produkty-02.jpg"
            });
            products.Add(new Product
            {
                Id = 3,
                Name = "Bageta",
                Description = "nejlepší bageta ve vesmíru",
                Price = 40,
                ImageSrc = "/img/products/produkty-05.jpg"
            });

            return products;
        }
    }
}
