using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace Events.Data.Entities
{
    public class EventEntity : BaseEntity
    {
        public string Name { get; set; }
        
        public string Description { get; set; }

        public DateTimeOffset DateTime { get; set; }
        
        public PlanEntity Plan { get; set; }
        
        public AddressEntity Address { get; set; }
        
        public Guid OrganizerId { get; set; }

        [ForeignKey(nameof(OrganizerId))]
        public OrganizerEntity Organizer { get; set; } 

    }
}