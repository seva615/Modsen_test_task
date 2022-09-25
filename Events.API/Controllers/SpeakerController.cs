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
    public class SpeakerController : Controller
    {
        private readonly ISpeakerService _speakerService;
        private readonly IMapper _mapper;

        public SpeakerController(ISpeakerService speakerService, IMapper mapper)
        {
            _mapper = mapper;
            _speakerService = speakerService;
        }

        [HttpGet]
        [Route("getSpeakers")]
        public async Task<IEnumerable<SpeakerViewModel>> GetAllSpeakers()
        {
            var speakerModels = await _speakerService.GetAllSpeakers();
            var speakerViewModels = _mapper.Map<IEnumerable<SpeakerViewModel>>(speakerModels);
            return speakerViewModels;
        }

        [HttpGet]
        [Route("getSpeaker")]
        public async Task<SpeakerViewModel> GetSpeaker(Guid id)
        {
            var speakerModel = await _speakerService.GetSpeaker(id);
            var speakerViewModel = _mapper.Map<SpeakerModel, SpeakerViewModel>(speakerModel);
            return speakerViewModel;
        }

        [HttpPost]
        [Authorize]
        [Route("addSpeaker")]
        public async Task AddSpeaker(CreateSpeakerViewModel speaker)
        {
            var speakerModel = _mapper.Map<CreateSpeakerViewModel, SpeakerModel>(speaker);
            await _speakerService.AddSpeaker(speakerModel);
        }

        [HttpPut]
        [Authorize]
        [Route("editSpeaker")]
        public async Task EditSpeaker(EditSpeakerViewModel speaker)
        {
            var speakerModel = _mapper.Map<EditSpeakerViewModel, SpeakerModel>(speaker);
            await _speakerService.EditSpeaker(speakerModel);
        }

        [HttpDelete]
        [Authorize]
        [Route("deleteSpeaker")]
        public async Task DeleteSpeaker(Guid id)
        {
            await _speakerService.DeleteSpeaker(id);
        }
    }
}