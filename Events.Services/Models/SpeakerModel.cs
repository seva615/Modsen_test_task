using System;
using System.Collections.Generic;

namespace Events.Services.Models
{
    public class SpeakerModel : BaseModel
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public IEnumerable<SpeechModel> Speeches { get; set; }
    }
}