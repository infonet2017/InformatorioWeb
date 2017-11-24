using System;
using System.Collections.Generic;

namespace DataAccess.models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            UsuariosRoles = new HashSet<UsuariosRoles>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public int? Telefono { get; set; }
        public int IdRol { get; set; }
        public int IdLocalidad { get; set; }

        public virtual ICollection<UsuariosRoles> UsuariosRoles { get; set; }
    }
}
