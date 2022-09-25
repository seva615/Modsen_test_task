using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Events.Data.Entities
{
    public class SpeechEntity : BaseEntity
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public DateTimeOffset DateTime { get; set; }
        
        public Guid PlanId { get; set; }
        
        public Guid SpeakerId { get; set; }
        
        [ForeignKey(nameof(PlanId))]
        public PlanEntity Plan { get; set; }
        
        [ForeignKey(nameof(SpeakerId))]
        public SpeakerEntity Speaker { get; set; }
    }
}