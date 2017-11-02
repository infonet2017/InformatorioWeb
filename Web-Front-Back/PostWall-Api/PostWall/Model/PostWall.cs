using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostWall.Model
{
    public class PostWall
    {
        public int ID { get; set; }
        public string Module { get; set; }
        public List<Post> Posts { get; set; }

    }
}
