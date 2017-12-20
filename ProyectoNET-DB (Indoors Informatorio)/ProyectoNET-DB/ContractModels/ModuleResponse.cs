using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoNET_DB.Models.RestModels
{
    public class ModuleResponse
    {
        public int ID { get; set; }
        public int idCourse { get; set; }

        public List<ModuleModel> modules { get; set; }
    }
}
