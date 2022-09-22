using System;


namespace Events.Data.Entities
{
    public class SpeachEntity : BaseEntity
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public Guid PlanId { get; set; }
        
        public PlanEntity Plan { get; set; }
        
        public SpeakerEntity Speaker { get; set; }
    }
}