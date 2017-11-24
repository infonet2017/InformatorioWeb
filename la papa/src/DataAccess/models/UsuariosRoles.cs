using System;
using System.Collections.Generic;

namespace DataAccess.models
{
    public partial class UsuariosRoles
    {
        public UsuariosRoles()
        {
            Teacher = new HashSet<Teacher>();
        }

        public int IdUsuarioRol { get; set; }
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }

        public virtual ICollection<Teacher> Teacher { get; set; }
        public virtual Roles IdRolNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
