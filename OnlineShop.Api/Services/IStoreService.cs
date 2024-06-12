using System.Collections.Generic;
using OnlineShop.Api.Dtos;

namespace OnlineShop.Api.Services
{
    public interface IStoreService
    {
        IEnumerable<StoreDto> GetAllStores();
        StoreDto GetStoreById(int id);
        void CreateStore(StoreDto StoreDto);
        void UpdateStore(int id, StoreDto StoreDto);
        void DeleteStore(int id);
    }
}
