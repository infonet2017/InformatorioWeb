using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoNET_DB.Extra_Models
{
    public class StudentResponse
    {
        public int id { get; set; }
        public List<StudentModel> Students { get; set; }
    }
}
