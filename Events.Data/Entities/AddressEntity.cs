﻿using System;


namespace Events.Data.Entities
{
    public class AddressEntity : BaseEntity
    {
        public string Country { get; set; }
        
        public string City { get; set; }
        
        public string Street { get; set; }
        
        public string Postcode { get; set; }
        
        public Guid? OrganizerId { get; set; }
        
        public Guid? EventId { get; set; }
        
        public OrganizerEntity Organizer { get; set; }
        
        public EventEntity Event { get; set; }
    }
}