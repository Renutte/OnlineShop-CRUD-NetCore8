using System.Collections.Generic;
using System.Linq;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Api.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly DataContext _context;

        public StoreRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Store> GetAll()
        {
            return _context.Stores.ToList();
        }

        public Store GetById(int id)
        {
            return _context.Stores.Find(id);
        }

        public void Add(Store Store)
        {
            _context.Stores.Add(Store);
            Save();
        }

        public void Update(Store Store)
        {
            _context.Stores.Update(Store);
            Save();
        }

        public void Delete(int id)
        {
            var store = GetById(id);
            if (store != null)
            {
                var storeProducts = _context.StoreProducts.Where(sp => sp.StoreId == id).ToList();
                _context.StoreProducts.RemoveRange(storeProducts);
                _context.Stores.Remove(store);
                Save();
            }
        }


        public void Save()
        {
            try
            {
                _context.SaveChanges();
            } catch
            {
                return;
            }
            
        }
    }
}
