using System;
using System.Collections.Generic;

namespace ProyectoNET_DB.Info2017
{
    public partial class Actualmodule
    {
        public int IdActualModule { get; set; }
        public int ActualModule { get; set; }
        public int IdTeacher { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; }
        public string NameCourse { get; set; }
    }
}
