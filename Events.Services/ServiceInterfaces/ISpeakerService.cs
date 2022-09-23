using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Events.Services.Models;

namespace Events.Services.ServiceInterfaces
{
    public interface ISpeakerService
    {
        public Task DeleteSpeaker(Guid id);
        
        public Task AddSpeaker(SpeakerModel speaker);

        public Task<SpeakerModel> GetSpeaker(Guid id);

        public Task<IEnumerable<SpeakerModel>> GetAllSpeakers();

        public Task EditSpeaker(SpeakerModel speaker);
    }
}