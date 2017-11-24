using System;
using System.Collections.Generic;

namespace DataAccess.models
{
    public partial class Post
    {
        public int IdPost { get; set; }
        public string Description { get; set; }
        public DateTime? DateTimePost { get; set; }
        public string Title { get; set; }
        public int ModuleIdmodule { get; set; }
        public int TeacherIdTeacher { get; set; }

        public virtual Module ModuleIdmoduleNavigation { get; set; }
        public virtual Teacher TeacherIdTeacherNavigation { get; set; }
    }
}
