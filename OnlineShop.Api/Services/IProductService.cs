using System.Collections.Generic;
using OnlineShop.Api.Dtos;

namespace OnlineShop.Api.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto GetProductById(int id);
        void CreateProduct(ProductDto productDto);
        void UpdateProduct(int id, ProductDto productDto);
        void DeleteProduct(int id);
    }
}
