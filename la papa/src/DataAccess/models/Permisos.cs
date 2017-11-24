using System;
using System.Collections.Generic;

namespace DataAccess.models
{
    public partial class Permisos
    {
        public Permisos()
        {
            RolesPermisos = new HashSet<RolesPermisos>();
        }

        public int IdPermiso { get; set; }
        public string Nombre { get; set; }
        public int Permiso { get; set; }
        public int Activo { get; set; }

        public virtual ICollection<RolesPermisos> RolesPermisos { get; set; }
    }
}
