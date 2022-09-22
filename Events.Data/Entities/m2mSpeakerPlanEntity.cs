using System;

namespace Events.Data.Entities
{
    public class m2mSpeakerPlanEntity
    {
        public Guid SpeakerId { get; set; }
        
        public Guid PlanId { get; set; }
    }
}