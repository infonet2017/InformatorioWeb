using System;
using System.Collections.Generic;

namespace ProyectoNET_DB.Info2017
{
    public partial class Auxiliarmodules
    {
        public Auxiliarmodules()
        {
            Teacher = new HashSet<Teacher>();
        }

        public int IdauxiliarModules { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdModule { get; set; }

        public ICollection<Teacher> Teacher { get; set; }
    }
}
