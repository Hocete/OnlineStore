using System;
using System.Collections.Generic;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Domain.Abstract
{
    public interface IProductsRepository
    {
        IEnumerable<Product> Products { get; }
        void Saveproduct(Product product);
        Product DeleteProduct(int productID);
    }
}
