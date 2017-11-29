using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoNET_LocalDB.Models.RestModels
{
    public class ModuleResponse
    {
        public int IDAlumno { get; set; }
        public int IDCurso { get; set; }

        public List<ModuleRest> Modulos { get; set; }
    }
}
