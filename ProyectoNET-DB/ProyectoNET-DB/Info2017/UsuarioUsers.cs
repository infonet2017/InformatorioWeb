using System;
using System.Collections.Generic;

namespace ProyectoNET_DB.Info2017
{
    public partial class UsuarioUsuarioUsers
    {
        public UsuarioUsuarioUsers()
        {
            Evaluation = new HashSet<Evaluation>();
            FeedbackIdStudentNavigation = new HashSet<Feedback>();
            FeedbackIdTeacherNavigation = new HashSet<Feedback>();
            Filedescription = new HashSet<Filedescription>();
            Post = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Password { get; set; }
        public DateTime? LastLogin { get; set; }
        public sbyte IsSuperuser { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public sbyte IsStaff { get; set; }
        public sbyte IsActive { get; set; }
        public DateTime DateJoined { get; set; }
        public int? Dni { get; set; }
        public long? Phone { get; set; }
        public string Address { get; set; }
        public int? IdLocality { get; set; }
        public int? IdRol { get; set; }
        public string Image { get; set; }

        public ICollection<Evaluation> Evaluation { get; set; }
        public ICollection<Feedback> FeedbackIdStudentNavigation { get; set; }
        public ICollection<Feedback> FeedbackIdTeacherNavigation { get; set; }
        public ICollection<Filedescription> Filedescription { get; set; }
        public ICollection<Post> Post { get; set; }
    }
}
