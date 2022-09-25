using System;

namespace Modsen_test_task.ViewModels
{
    public class EditAddressEvent
    {
        public Guid Id { get; set; }

        public Guid? EventId { get; set; }
    }
}