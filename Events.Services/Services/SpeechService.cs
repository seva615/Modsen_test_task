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
    public class SpeechService : ISpeechService
    {
        private readonly ISpeechRepository _speechRepository;
        private readonly IPlanRepository _planRepository;
        private readonly IMapper _mapper;

        public SpeechService(ISpeechRepository speechRepository, IPlanRepository planRepository, IMapper mapper)
        {
            _planRepository = planRepository;
            _speechRepository = speechRepository;
            _mapper = mapper;
        }

        public async Task DeleteSpeech(Guid id)
        {
            await _speechRepository.Delete(id);
        }

        public async Task AddSpeech(SpeechModel speech)
        {
            if (await _planRepository.GetById(speech.PlanId) != null)
            {
                var SpeechEntity = _mapper.Map<SpeechModel, SpeechEntity>(speech);
                await _speechRepository.Add(SpeechEntity);
            }
            else
            {
                throw new NotFoundException("No Event found with entered id");
            }
        }

        public async Task<SpeechModel> GetSpeech(Guid id)
        {
            var SpeechEntity = await _speechRepository.GetById(id);
            var SpeechModel = _mapper.Map<SpeechEntity, SpeechModel>(SpeechEntity);
            return SpeechModel;
        }

        public async Task EditSpeech(SpeechModel speech)
        {
            var SpeechEntity = _mapper.Map<SpeechModel, SpeechEntity>(speech);
            await _speechRepository.Edit(SpeechEntity);
        }

        public async Task<IEnumerable<SpeechModel>> GetAllSpeeches()
        {
            var SpeechEntities = await _speechRepository.GetAll();
            var SpeechModels = _mapper.Map<IEnumerable<SpeechModel>>(SpeechEntities);
            return SpeechModels;
        }
    }
}