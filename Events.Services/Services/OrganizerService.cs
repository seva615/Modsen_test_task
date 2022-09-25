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


        public async Task<OrganizerModel> GetOrganizer(Guid id)
        {
            var organizerEntity = await _organizerRepository.GetById(id);
            var organizerModel = _mapper.Map<OrganizerEntity, OrganizerModel>(organizerEntity);
            return organizerModel;
        }

        public async Task EditOrganizer(OrganizerModel organizer)
        {
            var organizerEntity = _mapper.Map<OrganizerModel, OrganizerEntity>(organizer);
            await _organizerRepository.Edit(organizerEntity);
        }

        public async Task EditOrganizerRole( OrganizerModel organizer)
        {
            var entity = _organizerRepository.GetEntityById(organizer.Id);
            entity.Role = organizer.Role;
            var organizerEntity = _mapper.Map<OrganizerModel, OrganizerEntity>(organizer);
            await _organizerRepository.Edit(entity);
        }

        public async Task<IEnumerable<OrganizerModel>> GetAllOrganizers()
        {
            var organizerEntities = await _organizerRepository.GetAll();
            var organizerModels = _mapper.Map<IEnumerable<OrganizerModel>>(organizerEntities);
            return organizerModels;
        }
    }
}