using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoNET_DB.Info2017
{
    public partial class Feedback
    {
        public int Idfeedback { get; set; }
        public string Description { get; set; }
        public int IdEvaluation { get; set; }
        public int IdStudent { get; set; }
        public int? Note { get; set; }

        public Evaluation IdEvaluationNavigation { get; set; }

        [ForeignKey("IdStudent")]
        public UsuarioUsers IdStudentNavigation { get; set; }
    }
}
