using System;
using System.Collections.Generic;


namespace Events.Services.Models
{
    public class PlanModel : BaseModel
    {
        public string Title { get; set; }
        
        public Guid EventId { get; set; }

        public EventModel Event { get; set; } 
            
        public IEnumerable<SpeechModel> Speeches { get; set; }

    }
}