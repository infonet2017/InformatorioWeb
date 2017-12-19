using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoNET_DB.Extra_Models
{
    public class CourseResponse
    {
        public int id { get; set; }
        public int id_user { get; set; }
        public int id_course { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public int dni { get; set; }
        public string email { get; set; }


    }   
}
