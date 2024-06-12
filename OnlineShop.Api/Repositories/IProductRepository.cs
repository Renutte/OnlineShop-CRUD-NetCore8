using System.Collections.Generic;
using OnlineShop.Models;

namespace OnlineShop.Api.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        void Save();
    }
}
