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
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;        
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
        public async Task DeleteEvent(Guid id)
        {
            await _eventRepository.Delete(id);
        }

        public async Task AddEvent(EventModel eventModel)
        {
            var EventEntity = _mapper.Map<EventModel, EventEntity>(eventModel);
            await _eventRepository.Add(EventEntity);
        }

        public async Task<EventModel> GetEvent(Guid id)
        {
            var EventEntity = await _eventRepository.GetById(id);
            var EventModel = _mapper.Map<EventEntity, EventModel>(EventEntity);
            return EventModel;
        }

        public async Task EditEvent(EventModel eventModel)
        {
            var EventEntity = _mapper.Map<EventModel, EventEntity>(eventModel);
            await _eventRepository.Edit(EventEntity);
        }

        public async Task<IEnumerable<EventModel>> GetAllEvents()
        {
            var EventEntities = await _eventRepository.GetAll();
            var EventModels = _mapper.Map<IEnumerable<EventModel>>(EventEntities);
            return EventModels;
        }
    }
}