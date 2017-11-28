using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoNET_LocalDB.Models
{
    public class InfoDbContext: DbContext
    {

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Module> Modules { get; set; }

        public DbSet<ActualModule> ActualModules { get; set; }

        public InfoDbContext(DbContextOptions<InfoDbContext> options)
            : base(options)
        {

        }

        public InfoDbContext(): base()
        {

        }



    }
}
