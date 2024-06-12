using System.Collections.Generic;
using AutoMapper;
using OnlineShop.Api.Dtos;
using OnlineShop.Models;
using OnlineShop.Api.Repositories;

namespace OnlineShop.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public ProductDto GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            return _mapper.Map<ProductDto>(product);
        }

        public void CreateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _productRepository.Add(product);
        }

        public void UpdateProduct(int id, ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.Id = id;
            _productRepository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }
    }
}
