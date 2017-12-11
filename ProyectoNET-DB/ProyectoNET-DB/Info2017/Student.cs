using System;
using System.Collections.Generic;

namespace ProyectoNET_DB.Info2017
{
    public partial class Student
    {
        public int Idstudent { get; set; }
        public int IdUsuario { get; set; }
        public string Name { get; set; }

        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
