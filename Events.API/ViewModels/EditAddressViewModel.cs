using System;

namespace Modsen_test_task.ViewModels
{
    public class EditAddressViewModel
    {
        public Guid Id { get; set; }
        
        public string Country { get; set; }
        
        public string City { get; set; }
        
        public string Street { get; set; }
        
        public string Postcode { get; set; }
        
        public Guid? OrganizerId { get; set; }
        
        public Guid? EventId { get; set; }
    }
}