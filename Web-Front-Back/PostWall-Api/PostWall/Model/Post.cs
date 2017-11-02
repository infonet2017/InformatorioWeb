using System;
using System.Collections.Generic;
using System.Text;

namespace PostWall.Model
{
    public class Post
    {
        //here goes properties requiered for the business model
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Teacher { get; set; }
        public DateTime DateTime { get; set; }

        public Post()
        {
        }

        public Post(int Id, string Title, string Description, string Teacher, DateTime Day)
        {
            this.Id = Id; // este id cuando se implemente bd se va a hacer solo y hay que sacarlo de los constr
            this.Title = Title;
            this.Description = Description;
            this.Teacher = Teacher;
            this.DateTime = Day;
        }

    }
}
