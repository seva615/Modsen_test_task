using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Events.Services.Models;
using Events.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Modsen_test_task.ViewModels;

namespace Modsen_test_task.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        public AddressController(IAddressService addressService, IMapper mapper)
        {
            _mapper = mapper;
            _addressService = addressService;
        }

        [HttpGet]
        [Route("getAddresses")]
        public async Task<IEnumerable<AddressViewModel>> GetAllAddresses()
        {
            var addressModels = await _addressService.GetAllAddresses();
            var addressViewModels = _mapper.Map<IEnumerable<AddressViewModel>>(addressModels);
            return addressViewModels;
        }

        [HttpGet]
        [Route("getAddress")]
        public async Task<AddressViewModel> GetAddress(Guid id)
        {
            var addressModel = await _addressService.GetAddress(id);
            var addressViewModel = _mapper.Map<AddressModel, AddressViewModel>(addressModel);
            return addressViewModel;
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        [Route("addAddress")]
        public async Task AddAddress(CreateAddressViewModel address)
        {
            var addressModel = _mapper.Map<CreateAddressViewModel, AddressModel>(address);
            await _addressService.AddAddress(addressModel);
        }

        [HttpPut]
        [Authorize(Roles = Role.Admin)]
        [Route("editAddress")]
        public async Task EditAddress(EditAddressViewModel address)
        {
            var addressModel = _mapper.Map<EditAddressViewModel, AddressModel>(address);
            await _addressService.EditAddress(addressModel);
        }
        
        [HttpPut]
        [Route("editAddressEvent")]
        public async Task EditAddressEvent(EditAddressEvent address)
        {
            var addressModel = _mapper.Map<EditAddressEvent, AddressModel>(address);
            await _addressService.EditAddressEvent(addressModel);
        }

        [HttpDelete]
        [Authorize(Roles = Role.Admin)]
        [Route("deleteAddress")]
        public async Task DeleteAddress(Guid id)
        {
            await _addressService.DeleteAddress(id);
        }
    }
}