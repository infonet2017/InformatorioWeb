﻿using System;
using System.Collections.Generic;

namespace ProyectoNET_DB.Info2017
{
    public partial class Teacher
    {
        public int IdTeacher { get; set; }
        public string Name { get; set; }
        public int UsuariosIdUsuario { get; set; }
        public int IdAuxiliarModules { get; set; }

        public Auxiliarmodules IdAuxiliarModulesNavigation { get; set; }
        public Usuarios UsuariosIdUsuarioNavigation { get; set; }
    }
}
