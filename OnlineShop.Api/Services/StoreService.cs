using System.Collections.Generic;
using AutoMapper;
using OnlineShop.Api.Dtos;
using OnlineShop.Models;
using OnlineShop.Api.Repositories;

namespace OnlineShop.Api.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _StoreRepository;
        private readonly IMapper _mapper;

        public StoreService(IStoreRepository StoreRepository, IMapper mapper)
        {
            _StoreRepository = StoreRepository;
            _mapper = mapper;
        }

        public IEnumerable<StoreDto> GetAllStores()
        {
            var Stores = _StoreRepository.GetAll();
            return _mapper.Map<IEnumerable<StoreDto>>(Stores);
        }

        public StoreDto GetStoreById(int id)
        {
            var Store = _StoreRepository.GetById(id);
            return _mapper.Map<StoreDto>(Store);
        }

        public void CreateStore(StoreDto StoreDto)
        {
            var Store = _mapper.Map<Store>(StoreDto);
            _StoreRepository.Add(Store);
        }

        public void UpdateStore(int id, StoreDto StoreDto)
        {
            var Store = _mapper.Map<Store>(StoreDto);
            Store.Id = id;
            _StoreRepository.Update(Store);
        }

        public void DeleteStore(int id)
        {
            _StoreRepository.Delete(id);
        }
    }
}
