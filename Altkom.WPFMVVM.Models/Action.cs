using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.WPFMVVM.Models
{
    public class Action : BaseEntity
    {
        public int Number { get; set; }
        public string Name { get; set; }

        public IEnumerable<Event> Events { get; set; }
    }

    public class Event : BaseEntity
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Part Part { get; set; }
    }

    public class Part : BaseEntity
    {
        
        public string Name { get; set; }
        public string SerialNumber { get; set; }
    }


}
