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
    public class OrganizerService : IOrganizerService
    {
        private readonly IOrganizerRepository _organizerRepository;        
        private readonly IMapper _mapper;

        public OrganizerService(IOrganizerRepository organizerRepository, IMapper mapper)
        {
            _organizerRepository = organizerRepository;
            _mapper = mapper;
        }
        public async Task DeleteOrganizer(Guid id)
        {
            await _organizerRepository.Delete(id);
        }

        public async Task AddOrganizer(OrganizerModel organizer)
        {
            var OrganizerEntity = _mapper.Map<OrganizerModel, OrganizerEntity>(organizer);
            await _organizerRepository.Add(OrganizerEntity);
        }

        public async Task<OrganizerModel> GetOrganizer(Guid id)
        {
            var OrganizerEntity = await _organizerRepository.GetById(id);
            var OrganizerModel = _mapper.Map<OrganizerEntity, OrganizerModel>(OrganizerEntity);
            return OrganizerModel;
        }

        public async Task EditOrganizer(OrganizerModel organizer)
        {
            var OrganizerEntity = _mapper.Map<OrganizerModel, OrganizerEntity>(organizer);
            await _organizerRepository.Edit(OrganizerEntity);
        }

        public async Task<IEnumerable<OrganizerModel>> GetAllOrganizers()
        {
            var OrganizerEntities = await _organizerRepository.GetAll();
            var OrganizerModels = _mapper.Map<IEnumerable<OrganizerModel>>(OrganizerEntities);
            return OrganizerModels;
        }
    }
}