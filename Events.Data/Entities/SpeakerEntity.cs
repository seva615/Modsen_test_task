using System.Collections.Generic;

namespace Events.Data.Entities
{
    public class SpeakerEntity : BaseEntity
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public IEnumerable<SpeechEntity> Speeches { get; set; }
    }
}