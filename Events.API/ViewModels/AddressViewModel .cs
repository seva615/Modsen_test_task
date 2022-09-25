using System;
using Events.Data.Entities;

namespace Modsen_test_task.ViewModels
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }
        
        public string Country { get; set; }
        
        public string City { get; set; }
        
        public string Street { get; set; }
        
        public string Postcode { get; set; }

        public Guid? EventId { get; set; }
        
        //public OrganizerViewModel Organizer { get; set; }
        
        //public EventViewModel Event { get; set; }
    }
}