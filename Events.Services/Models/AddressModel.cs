using System;


namespace Events.Services.Models
{
    public class AddressModel : BaseModel
    {
        public string Country { get; set; }
        
        public string City { get; set; }
        
        public string Street { get; set; }
        
        public string Postcode { get; set; }
        
        public Guid? OrganizerId { get; set; }
        
        public Guid? EventId { get; set; }
        
        public OrganizerModel Organizer { get; set; }
        
        public EventModel Event { get; set; }
    }
}