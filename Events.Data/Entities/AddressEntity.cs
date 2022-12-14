using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Events.Data.Entities
{
    public class AddressEntity : BaseEntity
    {
        public string Country { get; set; }
        
        public string City { get; set; }
        
        public string Street { get; set; }
        
        public string Postcode { get; set; }

        public Guid? EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public EventEntity Event { get; set; }
    }
}