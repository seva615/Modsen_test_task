using System;

namespace Modsen_test_task.ViewModels
{
    public class CreateEventViewModel
    {
        public string Name { get; set; }
        
        public string Description { get; set; }

        public DateTimeOffset DateTime { get; set; }
        
        public Guid OrganizerId { get; set; }

    }
}