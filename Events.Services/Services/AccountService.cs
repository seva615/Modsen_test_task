using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Events.Data.DataInterfaces;
using Events.Data.Entities;
using Events.Services.Cryptography;
using Events.Services.Exceptions;
using Events.Services.Models;
using Events.Services.ServiceInterfaces;

namespace Events.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IOrganizerRepository _organizerRepository;
        private readonly IMapper _mapper;
        private readonly IAccountCryptographyService _cryptographyService;

        public AccountService(IOrganizerRepository organizerRepository, IMapper mapper, IAccountCryptographyService cryptographyService)
        {
            _cryptographyService = cryptographyService;
            _organizerRepository = organizerRepository;
            _mapper = mapper;
        }

        public async Task CreateAccount(OrganizerModel organizer)
        {
            if (_organizerRepository.GetByName(organizer.Name) != null)
            {
                throw new AccountCreatingException("This name already exists");
            }

            IEnumerable<OrganizerEntity> usersList = await _organizerRepository.GetAll();
            
            organizer.Role = !usersList.Any() ? Role.Admin : Role.User;
            
            var organizerEntity = _mapper.Map<OrganizerModel, OrganizerEntity>(organizer);
            organizerEntity.Password = _cryptographyService.HashPassword(organizerEntity.Password);

            await _organizerRepository.Add(organizerEntity);
        }

        public OrganizerModel Authorize(OrganizerModel organizer)
        {
            var organizerEntity = _mapper.Map<OrganizerModel, OrganizerEntity>(organizer);

            var dbOrganizer =  _organizerRepository.GetByName(organizerEntity.Name);

            if (dbOrganizer == null)
            {
                return null;
            }

            if (_cryptographyService.Authorize(organizerEntity.Password, dbOrganizer.Password))
            {
                organizer = _mapper.Map<OrganizerEntity, OrganizerModel>(dbOrganizer);

                return organizer;
            }

            return null;
        }

    }
}