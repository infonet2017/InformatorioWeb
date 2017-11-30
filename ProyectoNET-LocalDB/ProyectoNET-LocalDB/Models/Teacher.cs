using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoNET_LocalDB.Models
{
    public class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Module ModuleID { get; set; }
    }
}
