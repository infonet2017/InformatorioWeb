using System;
using System.Collections.Generic;

namespace DataAccess.models
{
    public partial class Feedback
    {
        public int Idfeedback { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int? IdTeacher { get; set; }
        public int? IdStudent { get; set; }
    }
}
