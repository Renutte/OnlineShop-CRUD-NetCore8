using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Api.Repositories
{
    public class StoreProductRepository : IStoreProductRepository
    {
        private readonly DataContext _context;

        public StoreProductRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<StoreProduct> GetAll()
        {
            return _context.StoreProducts
                           .Include(sp => sp.Store)
                           .Include(sp => sp.Product)
                           .ToList();
        }

        public StoreProduct GetById(int storeId, int productId)
        {
            return _context.StoreProducts
                           .Include(sp => sp.Store)
                           .Include(sp => sp.Product)
                           .FirstOrDefault(sp => sp.StoreId == storeId && sp.ProductId == productId);
        }

        public void Add(StoreProduct storeProduct)
        {
            _context.StoreProducts.Add(storeProduct);
            Save();
        }

        public void Update(StoreProduct storeProduct)
        {
            var existingEntity = _context.StoreProducts.Find(storeProduct.StoreId, storeProduct.ProductId);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(storeProduct);
                Save();
            }
        }


        public void Delete(int storeId, int productId)
        {
            var storeProduct = GetById(storeId, productId);
            if (storeProduct != null)
            {
                _context.StoreProducts.Remove(storeProduct);
                Save();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
