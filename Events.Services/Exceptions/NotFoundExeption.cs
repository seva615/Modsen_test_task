using System;
using System.Collections.Generic;
using System.Text;

namespace Events.Services
{
    [Serializable]
   public class NotFoundException : Exception
    {       
        public NotFoundException() { }

        public NotFoundException(string message)
            : base(message) { }

        public NotFoundException(string message, Exception inner)
            : base(message, inner) { }
   }
}
