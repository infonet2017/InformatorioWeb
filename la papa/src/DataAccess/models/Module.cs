using System;
using System.Collections.Generic;

namespace DataAccess.models
{
    public partial class Module
    {
        public Module()
        {
            Evaluation = new HashSet<Evaluation>();
            ModuleUser = new HashSet<ModuleUser>();
            Post = new HashSet<Post>();
            Support = new HashSet<Support>();
            Teacher = new HashSet<Teacher>();
        }

        public int Idmodule { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Evaluation> Evaluation { get; set; }
        public virtual ICollection<ModuleUser> ModuleUser { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<Support> Support { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
    }
}
