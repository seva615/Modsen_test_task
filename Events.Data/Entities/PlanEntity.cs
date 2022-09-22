using System;
using System.Collections.Generic;
using Events.Data.DataInterfaces;

namespace Events.Data.Entities
{
    public class PlanEntity : EntityAbstract
    {
        public String PlanDescription { get; set; }
        
        public IEnumerable<SpeakerEntity> Speaker { get; set; }
    }
}