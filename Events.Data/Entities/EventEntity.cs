using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Events.Data.DataInterfaces;

namespace Events.Data.Entities
{
    public class EventEntity : BaseEntity
    {
        public string Name { get; set; }
        
        public string Description { get; set; }

        public DateTimeOffset DateTime { get; set; }
        
        public PlanEntity Plan { get; set; }
        
        public AddressEntity Address { get; set; }

        public IEnumerable<OrganizerEntity> Organaizers { get; set; } 

    }
}