using System;
using System.Collections.Generic;

namespace Modsen_test_task.ViewModels
{
    public class OrganizerViewModel
    {
        public  Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Password { get; set; }
        
        public string Role { get; set; }
        
        public AddressViewModel Address { get; set; }

        public IEnumerable<EventViewModel> Events { get; set; } 
    }
    static class Role
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
    
}