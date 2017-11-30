using Microsoft.EntityFrameworkCore;

namespace ProyectoNET_LocalDB.Models
{
    public class InfoDbContext: DbContext
    {

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Module> Modules { get; set; }

        public DbSet<ActualModule> ActualModules { get; set; }

        public DbSet<FileDescription> FileDescriptions { get; set; }
        



        public InfoDbContext(DbContextOptions<InfoDbContext> options)
            : base(options)
        {

        }

        public InfoDbContext(): base()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FileDescription>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }



    }
}
