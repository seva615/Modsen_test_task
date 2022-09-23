using System;
using System.Collections.Generic;

namespace Modsen_test_task.ViewModels
{
    public class PlanViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Guid EventId { get; set; }

        public EventViewModel Event { get; set; }

        public IEnumerable<SpeechViewModel> Speeches { get; set; }
    }
}