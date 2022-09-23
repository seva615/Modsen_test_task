using System;
using System.Collections.Generic;


namespace Modsen_test_task.ViewModels
{
    public class SpeakerViewModel
    {
        public Guid Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public IEnumerable<SpeechViewModel> Speeches { get; set; }
    }
}