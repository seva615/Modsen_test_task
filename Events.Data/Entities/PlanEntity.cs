using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Events.Data.Entities
{
    public class PlanEntity : BaseEntity
    {
        public string Title { get; set; }
        
        public Guid EventId { get; set; }
        
        [ForeignKey(nameof(EventId))]
        public EventEntity Event { get; set; } 
            
        public IEnumerable<SpeechEntity> Speeches { get; set; }

    }
}