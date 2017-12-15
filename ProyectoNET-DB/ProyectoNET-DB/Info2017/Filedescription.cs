using System;
using System.Collections.Generic;

namespace ProyectoNET_DB.Info2017
{
    public partial class Filedescription
    {
        public int IdfileDescription { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedTimestamp { get; set; }
        public DateTime? UpdatedTimestamp { get; set; }
        public string ContentType { get; set; }
        public int IdModule { get; set; }
        public int IdTeacher { get; set; }
        public bool IsDeleted { get; set; }
        public string TeacherName { get; set; }
        public string ModuleName { get; set; }

        public Module IdModuleNavigation { get; set; }
        public Users IdTeacherNavigation { get; set; }
    }
}
