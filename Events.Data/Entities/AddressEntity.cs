using System;
using Events.Data.DataInterfaces;

namespace Events.Data.Entities
{
    public class AddressEntity : EntityAbstract
    {
        public String Country { get; set; }
        
        public String City { get; set; }
        
        public String Street { get; set; }
        
        public String Postcode { get; set; }
        
        public Guid EntityId { get; set; }
    }
}