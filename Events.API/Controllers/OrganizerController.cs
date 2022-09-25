using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Events.Services.Models;
using Events.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modsen_test_task.ViewModels;

namespace Modsen_test_task.Controllers
{
    public class OrganizerController : Controller
    {
        private readonly IOrganizerService _organizerService;
        private readonly IMapper _mapper;

        public OrganizerController(IOrganizerService organizerService, IMapper mapper)
        {
            _mapper = mapper;
            _organizerService = organizerService;
        }

        [HttpGet]
        [Route("getOrganizers")]
        public async Task<IEnumerable<OrganizerViewModel>> GetAllOrganizers()
        {
            var organizerModels = await _organizerService.GetAllOrganizers();
            var organizerViewModels = _mapper.Map<IEnumerable<OrganizerViewModel>>(organizerModels);
            return organizerViewModels;
        }
        
        [HttpPut]
        [Authorize(Roles = Role.Admin)]
        [Route("editOrganizerRole")]
        public async Task EditOrganizerRole(EditOrganizerRole organizer)
        {
            var organizerModel = _mapper.Map<EditOrganizerRole, OrganizerModel>(organizer);
            await _organizerService.EditOrganizerRole(organizerModel);
        }
        

        [HttpGet]
        [Route("getOrganizer")]
        public async Task<OrganizerViewModel> GetOrganizer(Guid id)
        {
            var organizerModel = await _organizerService.GetOrganizer(id);
            var organizerViewModel = _mapper.Map<OrganizerModel, OrganizerViewModel>(organizerModel);
            return organizerViewModel;
        }

        [HttpDelete]
        [Authorize(Roles = Role.Admin)]
        [Route("deleteOrganizer")]
        
        public async Task DeleteOrganizer(Guid id)
        {
            await _organizerService.DeleteOrganizer(id);
        }
    }
}