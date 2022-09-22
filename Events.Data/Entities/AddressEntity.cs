using System;
using Events.Data.DataInterfaces;

namespace Events.Data.Entities
{
    public class AddressEntity : BaseEntity
    {
        public string Country { get; set; }
        
        public string City { get; set; }
        
        public string Street { get; set; }
        
        public string Postcode { get; set; }
        
        public Guid? OrganaizerId { get; set; }
        
        public Guid? EventId { get; set; }
        
        public OrganizerEntity Organaizer { get; set; }
        
        public EventEntity Event { get; set; }
    }
}