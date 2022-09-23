using System;
using System.Collections.Generic;


namespace Events.Services.Models
{
    public class OrganizerModel : BaseModel 
    {
       public string Name { get; set; }
        
        public AddressModel Address { get; set; }

        public IEnumerable<EventModel> Events { get; set; } 
    }
}