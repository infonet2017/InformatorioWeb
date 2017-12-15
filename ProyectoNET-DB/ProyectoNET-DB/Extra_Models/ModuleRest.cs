using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoNET_DB.Models.RestModels
{
    public class ModuleRest
    {
        public int ID { get; set; }
        public int IDModulo { get; set; }
        public List<DocenteRest> Docentes { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }

    }
}
