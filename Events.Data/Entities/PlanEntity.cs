using System;
using System.Collections.Generic;
using Events.Data.DataInterfaces;

namespace Events.Data.Entities
{
    public class PlanEntity : BaseEntity
    {
        public string Title { get; set; }
        
        public Guid EventId { get; set; }

        public EventEntity Event { get; set; } 
            
        public IEnumerable<SpeachEntity> Speaches { get; set; }

    }
}