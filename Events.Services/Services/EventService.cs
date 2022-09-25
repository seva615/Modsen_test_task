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
        private readonly IOrganizerRepository _organizerRepository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper, IOrganizerRepository organizerRepository)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _organizerRepository = organizerRepository;
        }
        public async Task DeleteEvent(Guid id)
        {
            await _eventRepository.Delete(id);
        }

        public async Task AddEvent(EventModel eventModel)
        {
           
            //var entity = _organizerRepository.GetEntityById(id);
           // eventModel.Organizer = entity
            //eventModel.Organizer = _mapper.Map<OrganizerEntity,OrganizerModel>(entity);
            var eventEntity = _mapper.Map<EventModel, EventEntity>(eventModel);
            await _eventRepository.Add(eventEntity);
        }

        public async Task<EventModel> GetEvent(Guid id)
        {
            var eventEntity = await _eventRepository.GetById(id);
            var eventModel = _mapper.Map<EventEntity, EventModel>(eventEntity);
            return eventModel;
        }

        public async Task EditEvent(EventModel eventModel)
        {
            var eventEntity = _mapper.Map<EventModel, EventEntity>(eventModel);
            await _eventRepository.Edit(eventEntity);
        }

        public async Task<IEnumerable<EventModel>> GetAllEvents()
        {
            var eventEntities = await _eventRepository.GetAll();
            var eventModels = _mapper.Map<IEnumerable<EventModel>>(eventEntities);
            return eventModels;
        }
    }
}