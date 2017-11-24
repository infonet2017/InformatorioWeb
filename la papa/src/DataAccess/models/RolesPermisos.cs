using System;
using System.Collections.Generic;

namespace DataAccess.models
{
    public partial class RolesPermisos
    {
        public int IdRolPermiso { get; set; }
        public int IdRol { get; set; }
        public int IdPermiso { get; set; }

        public virtual Permisos IdPermisoNavigation { get; set; }
        public virtual Roles IdRolNavigation { get; set; }
    }
}
