using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Events.Services.Models;

namespace Events.Services.ServiceInterfaces
{
    public interface IAddressService
    {
        public Task DeleteAddress(Guid id);

        public Task AddAddress(AddressModel address);

        public Task<AddressModel> GetAddress(Guid id);

        public Task EditAddress(AddressModel address);

        public Task<IEnumerable<AddressModel>> GetAllAddresses();
    }
}