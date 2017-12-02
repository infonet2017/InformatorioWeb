using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoNET_LocalDB.Models
{
    public class Module
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Post> Posts { get; set; }
        public virtual List<Teacher> Teachers { get; set; }
        public List<FileDescription> FileShortDescriptions { get; set; }
        public virtual List<Evaluation> Evaluations { get; set; }
        public virtual List<Student> Students {get;set;}
    }
}
