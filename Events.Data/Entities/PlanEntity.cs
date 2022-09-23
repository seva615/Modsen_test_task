using System;
using System.Collections.Generic;


namespace Events.Data.Entities
{
    public class PlanEntity : BaseEntity
    {
        public string Title { get; set; }
        
        public Guid EventId { get; set; }

        public EventEntity Event { get; set; } 
            
        public IEnumerable<SpeechEntity> Speeches { get; set; }

    }
}