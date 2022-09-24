using System;
using System.Collections.Generic;


namespace Events.Services.Models
{
    public class OrganizerModel : BaseModel
    {
        public string Name { get; set; }

        public string Password { get; set; }
        
        public string Role { get; set; }

        public AddressModel Address { get; set; }

        public IEnumerable<EventModel> Events { get; set; }
    }
    static class Role
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}