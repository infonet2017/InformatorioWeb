using System;
using System.Collections.Generic;

namespace DataAccess.models
{
    public partial class Assistancesheet
    {
        public int IdAssistanceSheet { get; set; }
        public int IdModule { get; set; }
        public int IdStudent { get; set; }
        public int IdTeacher { get; set; }
        public DateTime? Date { get; set; }
        public string Assisted { get; set; }
    }
}
