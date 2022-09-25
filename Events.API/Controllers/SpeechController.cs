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
    public class SpeechController : Controller
    {
        private readonly ISpeechService _speechService;
        private readonly IMapper _mapper;

        public SpeechController(ISpeechService speechService, IMapper mapper)
        {
            _mapper = mapper;
            _speechService = speechService;
        }

        [HttpGet]
        [Route("getSpeeches")]
        public async Task<IEnumerable<SpeechViewModel>> GetAllSpeeches()
        {
            var speechModels = await _speechService.GetAllSpeeches();
            var speechViewModels = _mapper.Map<IEnumerable<SpeechViewModel>>(speechModels);
            return speechViewModels;
        }

        [HttpGet]
        [Route("getSpeech")]
        public async Task<SpeechViewModel> GetSpeech(Guid id)
        {
            var speechModel = await _speechService.GetSpeech(id);
            var speechViewModel = _mapper.Map<SpeechModel, SpeechViewModel>(speechModel);
            return speechViewModel;
        }

        [HttpPost]
        [Authorize]
        [Route("addSpeech")]
        public async Task AddSpeech(CreateSpeechViewModel speech)
        {
            var speechModel = _mapper.Map<CreateSpeechViewModel, SpeechModel>(speech);
            await _speechService.AddSpeech(speechModel);
        }

        [HttpPut]
        [Authorize]
        [Route("editSpeech")]
        public async Task EditSpeech(EditSpeechViewModel speech)
        {
            var speechModel = _mapper.Map<EditSpeechViewModel, SpeechModel>(speech);
            await _speechService.EditSpeech(speechModel);
        }

        [HttpDelete]
        [Authorize]
        [Route("deleteSpeech")]
        public async Task DeleteSpeech(Guid id)
        {
            await _speechService.DeleteSpeech(id);
        }
    }
}