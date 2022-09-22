using System;

namespace Events.Data.Entities
{
    public class m2mOrganaizerEventEntity
    {
        public Guid EventId { get; set; }
        
        public Guid OrganaizerId { get; set; }
    }
}