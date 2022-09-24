using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Events.Services.Models;

namespace Events.Services.ServiceInterfaces
{
    public interface IOrganizerService
    {
        public Task DeleteOrganizer(Guid id);

        public Task<OrganizerModel> GetOrganizer(Guid id);

        public Task<IEnumerable<OrganizerModel>> GetAllOrganizers();

        public Task EditOrganizer(OrganizerModel organizer);
    }
}