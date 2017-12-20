using System;
using System.Collections.Generic;

namespace ProyectoNET_DB.Info2017
{
    public partial class Teacher
    {
        public int IdTeacher { get; set; }
        public int IdUser { get; set; }
        public int IdAuxiliarModules { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }

        public Auxiliarmodules IdAuxiliarModulesNavigation { get; set; }
    }
}
