using System.Collections.Generic;
using System.Linq;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            Save();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            Save();
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                // Obtener todos los registros de StoreProducts asociados a este producto
                var storeProducts = _context.StoreProducts.Where(sp => sp.ProductId == id).ToList();

                // Eliminar todos los registros de StoreProducts asociados a este producto
                _context.StoreProducts.RemoveRange(storeProducts);

                // Eliminar el producto
                _context.Products.Remove(product);

                // Guardar los cambios
                Save();
            }
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
