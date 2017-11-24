using DataAccess.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class PostRepository
    {
        private readonly InfoContext _context;



        public PostRepository(InfoContext context)
        {
            _context = context;

        }

        public IEnumerable<Post> GetAll()
        {
           return _context.Posts.ToList();
        }

      
    }
}
