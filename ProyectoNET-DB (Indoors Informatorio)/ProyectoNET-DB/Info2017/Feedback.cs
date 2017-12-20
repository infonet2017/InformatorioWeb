using System;
using System.Collections.Generic;

namespace ProyectoNET_DB.Info2017
{
    public partial class Feedback
    {
        public int Idfeedback { get; set; }
        public string Description { get; set; }
        public int IdEvaluation { get; set; }
        public int IdStudent { get; set; }
        public int Note { get; set; }
        public string NameStudent { get; set; }

        public Evaluation IdEvaluationNavigation { get; set; }
    }
}
