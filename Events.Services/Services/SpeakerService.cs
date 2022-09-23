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
    public class SpeakerService : ISpeakerService
    {
        private readonly ISpeakerRepository _speakerRepository;        
        private readonly IMapper _mapper;

        public SpeakerService(ISpeakerRepository speakerRepository, IMapper mapper)
        {
            _speakerRepository = speakerRepository;
            _mapper = mapper;
        }
        public async Task DeleteSpeaker(Guid id)
        {
            await _speakerRepository.Delete(id);
        }

        public async Task AddSpeaker(SpeakerModel speaker)
        {
            var SpeakerEntity = _mapper.Map<SpeakerModel, SpeakerEntity>(speaker);
            await _speakerRepository.Add(SpeakerEntity);
        }

        public async Task<SpeakerModel> GetSpeaker(Guid id)
        {
            var SpeakerEntity = await _speakerRepository.GetById(id);
            var SpeakerModel = _mapper.Map<SpeakerEntity, SpeakerModel>(SpeakerEntity);
            return SpeakerModel;
        }

        public async Task EditSpeaker(SpeakerModel speaker)
        {
            var SpeakerEntity = _mapper.Map<SpeakerModel, SpeakerEntity>(speaker);
            await _speakerRepository.Edit(SpeakerEntity);
        }

        public async Task<IEnumerable<SpeakerModel>> GetAllSpeakers()
        {
            var SpeakerEntities = await _speakerRepository.GetAll();
            var SpeakerModels = _mapper.Map<IEnumerable<SpeakerModel>>(SpeakerEntities);
            return SpeakerModels;
        }
    }
}