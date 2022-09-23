using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Events.Services.Models;
using Events.Services.ServiceInterfaces;
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

        [HttpGet]
        [Route("getOrganizer")]
        public async Task<OrganizerViewModel> GetOrganizer(Guid id)
        {
            var organizerModel = await _organizerService.GetOrganizer(id);
            var organizerViewModel = _mapper.Map<OrganizerModel, OrganizerViewModel>(organizerModel);
            return organizerViewModel;
        }

        [HttpPost]
        [Route("addOrganizer")]
        public async Task AddOrganizer(CreateOrganizerViewModel organizer)
        {
            var organizerModel = _mapper.Map<CreateOrganizerViewModel, OrganizerModel>(organizer);
            await _organizerService.AddOrganizer(organizerModel);
        }

        [HttpPut]
        [Route("editOrganizer")]
        public async Task EditOrganizer(OrganizerViewModel organizer)
        {
            var organizerModel = _mapper.Map<OrganizerViewModel, OrganizerModel>(organizer);
            await _organizerService.EditOrganizer(organizerModel);
        }

        [HttpDelete]
        [Route("deleteOrganizer")]
        public async Task DeleteOrganizer(Guid id)
        {
            await _organizerService.DeleteOrganizer(id);
        }
    }
}