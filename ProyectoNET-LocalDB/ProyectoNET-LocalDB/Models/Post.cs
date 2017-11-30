using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoNET_LocalDB.Models
{
    public class Post
    {
        //here goes properties requiered for the business model
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual Teacher Teacher { get; set; }
        public string NameTeacher { get; set; }
        public Module Module { get; set; }
        public DateTime DateTime { get; set; }

        public static implicit operator List<object>(Post v)
        {
            throw new NotImplementedException();
        }
    }
}
