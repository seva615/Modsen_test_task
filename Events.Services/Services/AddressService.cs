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
            var AddressEntity = _mapper.Map<AddressModel, AddressEntity>(address);
            await _addressRepository.Add(AddressEntity);
        }

        public async Task<AddressModel> GetAddress(Guid id)
        {
            var AddressEntity = await _addressRepository.GetById(id);
            var AddressModel = _mapper.Map<AddressEntity, AddressModel>(AddressEntity);
            return AddressModel;
        }

        public async Task EditAddress(AddressModel address)
        {
            var AddressEntity = _mapper.Map<AddressModel, AddressEntity>(address);
            await _addressRepository.Edit(AddressEntity);
        }

        public async Task<IEnumerable<AddressModel>> GetAllAddresses()
        {
            var AddressEntities = await _addressRepository.GetAll();
            var AddressModels = _mapper.Map<IEnumerable<AddressModel>>(AddressEntities);
            return AddressModels;
        }
    }
}