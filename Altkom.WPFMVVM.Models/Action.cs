using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.WPFMVVM.Models
{
    public class Action : BaseEntity
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }
        
    }

    public class Event : BaseEntity
    {
        public static TimeSpan Minimum => TimeSpan.Parse("06:00:00");
        public static TimeSpan Maximum => TimeSpan.Parse("14:00:00");

        public TimeSpan FromTime => From.TimeOfDay.Subtract(Minimum);
        public TimeSpan ToTime => To.TimeOfDay.Subtract(Minimum);

        public TimeSpan Duration => To - From;

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
