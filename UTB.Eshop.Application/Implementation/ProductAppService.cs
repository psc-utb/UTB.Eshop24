using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Application.Implementation
{
    public class ProductAppService : IProductAppService
    {
        EshopDbContext _eshopDbContext;
        IFileUploadService _fileUploadService;

        public ProductAppService(EshopDbContext eshopDbContext, IFileUploadService fileUploadService)
        {
            _eshopDbContext = eshopDbContext;
            _fileUploadService = fileUploadService;
        }

        public IList<Product> Select()
        {
            return _eshopDbContext.Products.ToList();
        }

        public void Create(Product product)
        {
            if (product.Image != null)
            {
                string imageSrc = _fileUploadService.FileUpload(product.Image, Path.Combine("img", "products"));
                product.ImageSrc = imageSrc;
            }

            _eshopDbContext.Products.Add(product);
            _eshopDbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Product? product
                = _eshopDbContext.Products.FirstOrDefault(prod => prod.Id == id);

            if (product != null)
            {
                _eshopDbContext.Products.Remove(product);
                _eshopDbContext.SaveChanges();
                deleted = true;
            }

            return deleted;
        }
    }
}

