using System;
using System.Collections.Generic;
using System.Text;

namespace Informatorio.WebInformatorio.Data
{
    public class InfoDbContext
    {
        public List<Post> Posts { get; set; }

        public InfoDbContext()
        {
            Posts = new List<Post>();

        }
        
    }
}
