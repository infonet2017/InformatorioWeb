using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoNET_DB.Models.RestModels
{
    public class ModuleResponse
    {
        public int ID { get; set; }
        public int IDTeacher { get; set; }
        public int IDCurso { get; set; }

        public List<ModuleRest> Modulos { get; set; }
    }
}
