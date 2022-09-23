using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Events.Services.Models;

namespace Events.Services.ServiceInterfaces
{
    public interface ISpeechService
    {
        public Task DeleteSpeech(Guid id);
        
        public Task AddSpeech(SpeechModel speech);

        public Task<SpeechModel> GetSpeech(Guid id);

        public Task<IEnumerable<SpeechModel>> GetAllSpeeches();

        public Task EditSpeech(SpeechModel speech);
    }
}