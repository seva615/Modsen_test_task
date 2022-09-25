using System;

namespace Modsen_test_task.ViewModels
{
    public class SpeechViewModel
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public DateTimeOffset DateTime { get; set; }
        
       // public Guid PlanId { get; set; }
        
        //public PlanViewModel Plan { get; set; }
        
        public SpeakerViewModel Speaker { get; set; }
    }
}