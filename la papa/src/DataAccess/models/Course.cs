using System;
using System.Collections.Generic;

namespace DataAccess.models
{
    public partial class Course
    {
        public Course()
        {
            Event = new HashSet<Event>();
        }

        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Inicio { get; set; }
        public string Final { get; set; }
        public string Direccion { get; set; }
        public string IdLocalidad { get; set; }

        public virtual ICollection<Event> Event { get; set; }
    }
}
