using System;


namespace Events.Services.Models
{
    public class SpeechModel : BaseModel
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public DateTimeOffset DateTime { get; set; }
        
        public Guid PlanId { get; set; }
        
        public PlanModel Plan { get; set; }
        
        public SpeakerModel Speaker { get; set; }
    }
}