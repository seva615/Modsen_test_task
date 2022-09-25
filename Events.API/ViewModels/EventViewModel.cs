using System;
using System.Collections.Generic;


namespace Modsen_test_task.ViewModels
{
    public class EventViewModel
    {
        public Guid Id { get; set; }
            
        public string Name { get; set; }
        
        public string Description { get; set; }

        public DateTimeOffset DateTime { get; set; }
        
        //public Guid OrganizerId { get; set; }
        
        public PlanViewModel Plan { get; set; }
        
        public AddressViewModel Address { get; set; }

        //public OrganizerViewModel Organizer { get; set; } 

    }
}