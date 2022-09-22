using System;
using Events.Data.DataInterfaces;

namespace Events.Data.Entities
{
    public class OrganizerEntity : EntityAbstract
    {
        public String OrganizerName { get; set; }
        
        public AddressEntity OrganaizerAddress { get; set; }
    }
}