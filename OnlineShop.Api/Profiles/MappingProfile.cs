using AutoMapper;
using OnlineShop.Models;
using OnlineShop.Api.Dtos;

namespace OnlineShop.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Store, StoreDto>().ReverseMap();
            CreateMap<StoreProduct, StoreProductDto>().ReverseMap();
        }
    }
}
