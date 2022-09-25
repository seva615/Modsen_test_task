using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Events.Services.Models
{
    public class EventModel : BaseModel
    {
        public string Name { get; set; }
        
        public string Description { get; set; }

        public DateTimeOffset DateTime { get; set; }
        
        public Guid OrganizerId { get; set; }
        
        public PlanModel Plan { get; set; }
        
        public AddressModel Address { get; set; }

        public OrganizerModel Organizer { get; set; } 

    }
}