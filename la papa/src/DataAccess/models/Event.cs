using System;
using System.Collections.Generic;

namespace DataAccess.models
{
    public partial class Event
    {
        public int Idevent { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Idschedule { get; set; }
        public string Location { get; set; }
        public int Idtype { get; set; }
        public int Idcourse { get; set; }

        public virtual Course IdcourseNavigation { get; set; }
        public virtual Schedule IdscheduleNavigation { get; set; }
    }
}
