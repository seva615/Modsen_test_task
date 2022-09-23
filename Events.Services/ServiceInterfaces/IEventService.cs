using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Events.Services.Models;

namespace Events.Services.ServiceInterfaces
{
    public interface IEventService
    {
        public Task DeleteEvent(Guid id);
        
        public Task AddEvent(EventModel eventModel);

        public Task<EventModel> GetEvent(Guid id);

        public Task<IEnumerable<EventModel>> GetAllEvents();

        public Task EditEvent(EventModel eventModel);
    }
}