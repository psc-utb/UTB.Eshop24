﻿using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Application.Implementation
{
    public class ProductAppService : IProductAppService
    {
        EshopDbContext _eshopDbContext;

        public ProductAppService(EshopDbContext eshopDbContext)
        {
            _eshopDbContext = eshopDbContext;
        }

        public IList<Product> Select()
        {
            return _eshopDbContext.Products.ToList();
        }

        public void Create(Product product)
        {
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

