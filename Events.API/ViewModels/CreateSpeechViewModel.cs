using System;

namespace Modsen_test_task.ViewModels
{
    public class CreateSpeechViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTimeOffset DateTime { get; set; }
        
        public Guid PlanId { get; set; }
        
        public Guid SpeakerId { get; set; }
    }
}