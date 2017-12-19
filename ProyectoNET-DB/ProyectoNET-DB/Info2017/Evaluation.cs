using System;
using System.Collections.Generic;

namespace ProyectoNET_DB.Info2017
{
    public partial class Evaluation
    {
        public Evaluation()
        {
            Feedback = new HashSet<Feedback>();
        }

        public int IdEvaluation { get; set; }
        public int IdModule { get; set; }
        public DateTime DateEvaluation { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int? IdTeacher { get; set; }

        public Modules IdModuleNavigation { get; set; }
        public UsuarioUsers IdTeacherNavigation { get; set; }
        public ICollection<Feedback> Feedback { get; set; }
    }
}
