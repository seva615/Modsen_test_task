using System;
using System.Collections;
using System.Collections.Generic;
using Events.Data.DataInterfaces;

namespace Events.Data.Entities
{
    public class EventEntity : EntityAbstract
    {
        public String EventName { get; set; }
        
        public String EventDescription { get; set; }

        public DateTimeOffset EventTime { get; set; }
        
        public PlanEntity EventPlan { get; set; }
        
        public AddressEntity EventAddress { get; set; }
        
        public IEnumerable<OrganizerEntity> EventOrganaizers { get; set; }

    }
}