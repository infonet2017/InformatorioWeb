using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoNET_DB.Info2017
{
    public partial class UsuarioUsers
    {
        public UsuarioUsers()
        {
            Evaluation = new HashSet<Evaluation>();
            Feedback = new HashSet<Feedback>();
            Filedescription = new HashSet<Filedescription>();
            Post = new HashSet<Post>();
        }

        [ForeignKey("UsuarioUsers")]
        public int Id { get; set; }
        public string Password { get; set; }
        public DateTime? LastLogin { get; set; }
        public Boolean IsSuperuser { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Boolean IsStaff { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime DateJoined { get; set; }
        public int? Dni { get; set; }
        public long? Phone { get; set; }
        public string Address { get; set; }
        public int? IdLocality { get; set; }
        public int? IdRol { get; set; }
        public string Image { get; set; }

        public ICollection<Evaluation> Evaluation { get; set; }

        public ICollection<Feedback> Feedback { get; set; }
        public ICollection<Filedescription> Filedescription { get; set; }
        public ICollection<Post> Post { get; set; }
    }
}
