using System;
using System.Collections.Generic;

namespace ProyectoNET_DB.Info2017
{
    public partial class Users
    {
        public Users()
        {
            FeedbackIdStudentNavigation = new HashSet<Feedback>();
            FeedbackIdTeacherNavigation = new HashSet<Feedback>();
            Filedescription = new HashSet<Filedescription>();
            Post = new HashSet<Post>();
            Student = new HashSet<Student>();
            Teacher = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }
        public int? IdRol { get; set; }
        public int? IdLocality { get; set; }

        public ICollection<Feedback> FeedbackIdStudentNavigation { get; set; }
        public ICollection<Feedback> FeedbackIdTeacherNavigation { get; set; }
        public ICollection<Filedescription> Filedescription { get; set; }
        public ICollection<Post> Post { get; set; }
        public ICollection<Student> Student { get; set; }
        public ICollection<Teacher> Teacher { get; set; }
    }
}
