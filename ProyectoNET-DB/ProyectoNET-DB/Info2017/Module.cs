using System;
using System.Collections.Generic;

namespace ProyectoNET_DB.Info2017
{
    public partial class Module
    {
        public Module()
        {
            Evaluation = new HashSet<Evaluation>();
            Filedescription = new HashSet<Filedescription>();
            Post = new HashSet<Post>();
        }

        public int Idmodule { get; set; }
        public string Name { get; set; }
        public int IdCourse { get; set; }
        public int IdModuleStudent { get; set; }
        public string Description { get; set; }

        public ICollection<Evaluation> Evaluation { get; set; }
        public ICollection<Filedescription> Filedescription { get; set; }
        public ICollection<Post> Post { get; set; }
    }
}
