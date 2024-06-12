using System.Collections.Generic;
using OnlineShop.Api.Dtos;

namespace OnlineShop.Api.Services
{
    public interface IStoreProductService
    {
        IEnumerable<StoreProductDto> GetAllStoreProducts();
        StoreProductDto GetStoreProductById(int storeId, int productId);
        void CreateStoreProduct(StoreProductDto StoreProductDto);
        void UpdateStoreProduct(int storeId, int productId, StoreProductDto StoreProductDto);
        void DeleteStoreProduct(int storeId, int productId);

        bool StoreProductExists(int storeId, int productId);
    }
}
