using System;
using System.Collections.Generic;

namespace DataAccess.models
{
    public partial class Schedule
    {
        public Schedule()
        {
            Event = new HashSet<Event>();
        }

        public int Idschedule { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Event> Event { get; set; }
    }
}
