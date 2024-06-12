using System.Collections.Generic;
using OnlineShop.Models;

namespace OnlineShop.Api.Repositories
{
    public interface IStoreRepository
    {
        IEnumerable<Store> GetAll();
        Store GetById(int id);
        void Add(Store product);
        void Update(Store product);
        void Delete(int id);
        void Save();
    }

}
