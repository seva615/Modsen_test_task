using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Events.Data.DataInterfaces;
using Events.Data.Entities;
using Events.Services.Models;
using Events.Services.ServiceInterfaces;

namespace Events.Services.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;        
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        public async Task DeleteAddress(Guid id)
        {
            await _addressRepository.Delete(id);
        }

        public async Task AddAddress(AddressModel address)
        {
            var addressEntity = _mapper.Map<AddressModel, AddressEntity>(address);
            await _addressRepository.Add(addressEntity);
        }

        public async Task<AddressModel> GetAddress(Guid id)
        {
            var addressEntity = await _addressRepository.GetById(id);
            var addressModel = _mapper.Map<AddressEntity, AddressModel>(addressEntity);
            return addressModel;
        }

        public async Task EditAddress(AddressModel address)
        {
            
            var addressEntity = _mapper.Map<AddressModel, AddressEntity>(address);
            await _addressRepository.Edit(addressEntity);
        }
        
        public async Task EditAddressEvent(AddressModel address)
        {
            var entity = _addressRepository.GetEntityById(address.Id);
            entity.EventId = address.EventId;
            await _addressRepository.Edit(entity);
        }

        public async Task<IEnumerable<AddressModel>> GetAllAddresses()
        {
            var addressEntities = await _addressRepository.GetAll();
            var addressModels = _mapper.Map<IEnumerable<AddressModel>>(addressEntities);
            return addressModels;
        }
    }
}