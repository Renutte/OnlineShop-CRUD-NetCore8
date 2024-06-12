using System.Collections.Generic;
using OnlineShop.Models;

namespace OnlineShop.Api.Repositories
{
    public interface IStoreProductRepository
    {
        IEnumerable<StoreProduct> GetAll();
        StoreProduct GetById(int storeId, int productId);
        void Add(StoreProduct product);
        void Update(StoreProduct product);
        void Delete(int storeId, int productId);
        void Save();
    }
}
