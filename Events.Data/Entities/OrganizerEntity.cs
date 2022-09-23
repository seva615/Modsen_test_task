using System;
using System.Collections.Generic;


namespace Events.Data.Entities
{
    public class OrganizerEntity : BaseEntity
    {
        public string Name { get; set; }
        
        public AddressEntity Address { get; set; }

        public IEnumerable<EventEntity> Events { get; set; } 
    }
}