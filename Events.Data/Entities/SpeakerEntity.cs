using System;
using Events.Data.DataInterfaces;

namespace Events.Data.Entities
{
    public class SpeakerEntity : EntityAbstract
    {
        public String SpeakerFirstName { get; set; }

        public String SpeakerLastName { get; set; }
    }
}