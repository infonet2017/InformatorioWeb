using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostWall.Model
{
    public class InfoDbContext: DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostWall> PostWall { get; set; }

        public InfoDbContext(DbContextOptions<InfoDbContext> options)
            : base(options)
        {

        }

        public InfoDbContext(): base()
        {

        }



    }
}
