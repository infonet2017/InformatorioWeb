using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoNET_DB.Models.RestModels
{
    public class ModuleModel
    {
        public int ID { get; set; }
        public int idModule { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<DocenteModel> teachers { get; set; }

    }
}
