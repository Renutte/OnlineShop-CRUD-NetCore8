using System.Collections.Generic;
using System.Linq;
using OnlineShop.Api.Dtos;
using OnlineShop.Api.Repositories;
using OnlineShop.Models;

namespace OnlineShop.Api.Services
{
    public class StoreProductService : IStoreProductService
    {
        private readonly IStoreProductRepository _storeProductRepository;

        public StoreProductService(IStoreProductRepository storeProductRepository)
        {
            _storeProductRepository = storeProductRepository;
        }

        public IEnumerable<StoreProductDto> GetAllStoreProducts()
        {
            var storeProducts = _storeProductRepository.GetAll();
            return storeProducts.Select(sp => new StoreProductDto
            {
                StoreId = sp.StoreId,
                ProductId = sp.ProductId,
                Stock = sp.Stock,
                Store = new StoreDto
                {
                    Id = sp.Store.Id,
                    Name = sp.Store.Name
                },
                Product = new ProductDto
                {
                    Id = sp.Product.Id,
                    Name = sp.Product.Name
                }
            }).ToList();
        }

        public StoreProductDto GetStoreProductById(int storeId, int productId)
        {
            var storeProduct = _storeProductRepository.GetById(storeId, productId);
            if (storeProduct == null) return null;

            return new StoreProductDto
            {
                StoreId = storeProduct.StoreId,
                ProductId = storeProduct.ProductId,
                Stock = storeProduct.Stock,
                Store = new StoreDto
                {
                    Id = storeProduct.Store.Id,
                    Name = storeProduct.Store.Name
                },
                Product = new ProductDto
                {
                    Id = storeProduct.Product.Id,
                    Name = storeProduct.Product.Name
                }
            };
        }

        public void CreateStoreProduct(StoreProductDto storeProductDto)
        {
            var storeProduct = new StoreProduct
            {
                StoreId = storeProductDto.StoreId,
                ProductId = storeProductDto.ProductId,
                Stock = storeProductDto.Stock
            };
            _storeProductRepository.Add(storeProduct);
        }

        public void UpdateStoreProduct(int storeId, int productId, StoreProductDto storeProductDto)
        {
            var storeProduct = new StoreProduct
            {
                StoreId = storeId,
                ProductId = productId,
                Stock = storeProductDto.Stock
            };
            _storeProductRepository.Update(storeProduct);
        }

        public void DeleteStoreProduct(int storeId, int productId)
        {
            _storeProductRepository.Delete(storeId, productId);
        }

        public bool StoreProductExists(int storeId, int productId)
        {
            var existingStoreProduct = _storeProductRepository.GetById(storeId, productId);
            return existingStoreProduct != null;
        }
    }
}
