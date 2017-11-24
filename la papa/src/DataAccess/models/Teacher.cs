using System;
using System.Collections.Generic;

namespace DataAccess.models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Post = new HashSet<Post>();
        }

        public int IdTeacher { get; set; }
        public string Name { get; set; }
        public int ModuleIdmodule { get; set; }
        public int UsuariosRolesIdUsuarioRol { get; set; }

        public virtual ICollection<Post> Post { get; set; }
        public virtual Module ModuleIdmoduleNavigation { get; set; }
        public virtual UsuariosRoles UsuariosRolesIdUsuarioRolNavigation { get; set; }
    }
}
