using System;
using System.Collections.Generic;

namespace DataAccess.models
{
    public partial class Roles
    {
        public Roles()
        {
            RolesPermisos = new HashSet<RolesPermisos>();
            UsuariosRoles = new HashSet<UsuariosRoles>();
        }

        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public int Activo { get; set; }

        public virtual ICollection<RolesPermisos> RolesPermisos { get; set; }
        public virtual ICollection<UsuariosRoles> UsuariosRoles { get; set; }
    }
}
