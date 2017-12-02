using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoNET_LocalDB.Models
{
    public class Feedback
    {
        public int ID { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Evaluation Evaluation { get; set; }
        public string Description { get; set; }
        public int Note { get; set; }
    }
}
