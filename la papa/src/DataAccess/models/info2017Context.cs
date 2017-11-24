using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.models
{
    public partial class info2017Context : DbContext
    {
        public virtual DbSet<Assistancesheet> Assistancesheet { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Evaluation> Evaluation { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<Locality> Locality { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<ModuleStudent> ModuleStudent { get; set; }
        public virtual DbSet<ModuleUser> ModuleUser { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolesPermisos> RolesPermisos { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Support> Support { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<UsuariosRoles> UsuariosRoles { get; set; }

        // Unable to generate entity type for table 'info2017.student'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseMySql(@"server=localhost;port=3306;database=test;user=root;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assistancesheet>(entity =>
            {
                entity.HasKey(e => e.IdAssistanceSheet)
                    .HasName("PRIMARY");

                entity.ToTable("assistancesheet", "info2017");

                entity.HasIndex(e => e.IdModule)
                    .HasName("idModule_idx");

                entity.Property(e => e.IdAssistanceSheet)
                    .HasColumnName("idAssistanceSheet")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Assisted)
                    .HasColumnName("assisted")
                    .HasColumnType("char(1)")
                    .HasMaxLength(1);

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.IdModule)
                    .HasColumnName("idModule")
                    .HasColumnType("int(3)");

                entity.Property(e => e.IdStudent)
                    .HasColumnName("idStudent")
                    .HasColumnType("int(3)");

                entity.Property(e => e.IdTeacher)
                    .HasColumnName("idTeacher")
                    .HasColumnType("int(3)");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PRIMARY");

                entity.ToTable("course", "info2017");

                entity.Property(e => e.IdCurso)
                    .HasColumnName("idCurso")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.Property(e => e.Final)
                    .HasColumnName("final")
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.Property(e => e.IdLocalidad)
                    .HasColumnName("idLocalidad")
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.Property(e => e.Inicio)
                    .HasColumnName("inicio")
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Evaluation>(entity =>
            {
                entity.HasKey(e => e.IdEvaluation)
                    .HasName("PRIMARY");

                entity.ToTable("evaluation", "info2017");

                entity.HasIndex(e => e.ModuleIdmodule)
                    .HasName("fk_Evaluation_module1_idx");

                entity.Property(e => e.IdEvaluation)
                    .HasColumnName("idEvaluation")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModuleIdmodule)
                    .HasColumnName("module_idmodule")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.ModuleIdmoduleNavigation)
                    .WithMany(p => p.Evaluation)
                    .HasForeignKey(d => d.ModuleIdmodule)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_Evaluation_module1");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.Idevent)
                    .HasName("PRIMARY");

                entity.ToTable("event", "info2017");

                entity.HasIndex(e => e.Idcourse)
                    .HasName("fk_event_1_idx");

                entity.HasIndex(e => e.Idschedule)
                    .HasName("idschedule_idx");

                entity.Property(e => e.Idevent)
                    .HasColumnName("idevent")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.Property(e => e.Idcourse)
                    .HasColumnName("idcourse")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idschedule)
                    .HasColumnName("idschedule")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idtype)
                    .HasColumnName("idtype")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdcourseNavigation)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.Idcourse)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("idcourse");

                entity.HasOne(d => d.IdscheduleNavigation)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.Idschedule)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("idschedule");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.Idfeedback)
                    .HasName("PRIMARY");

                entity.ToTable("feedback", "info2017");

                entity.Property(e => e.Idfeedback)
                    .HasColumnName("idfeedback")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(150)")
                    .HasMaxLength(150);

                entity.Property(e => e.IdStudent).HasColumnType("int(11)");

                entity.Property(e => e.IdTeacher).HasColumnType("int(11)");

                entity.Property(e => e.Title)
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasKey(e => e.IdFile)
                    .HasName("PRIMARY");

                entity.ToTable("file", "info2017");

                entity.HasIndex(e => e.SupportIdSupport)
                    .HasName("fk_File_Support1_idx");

                entity.Property(e => e.IdFile)
                    .HasColumnName("idFile")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Extension)
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.Property(e => e.SupportId).HasColumnType("int(11)");

                entity.Property(e => e.SupportIdSupport)
                    .HasColumnName("Support_idSupport")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.SupportIdSupportNavigation)
                    .WithMany(p => p.File)
                    .HasForeignKey(d => d.SupportIdSupport)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_File_Support1");
            });

            modelBuilder.Entity<Locality>(entity =>
            {
                entity.HasKey(e => e.IdLocality)
                    .HasName("PRIMARY");

                entity.ToTable("locality", "info2017");

                entity.Property(e => e.IdLocality)
                    .HasColumnName("idLocality")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Povince)
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => e.Idmodule)
                    .HasName("PRIMARY");

                entity.ToTable("module", "info2017");

                entity.Property(e => e.Idmodule)
                    .HasColumnName("idmodule")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<ModuleStudent>(entity =>
            {
                entity.HasKey(e => e.IdModuleStudent)
                    .HasName("PRIMARY");

                entity.ToTable("module-student", "info2017");

                entity.Property(e => e.IdModuleStudent)
                    .HasColumnName("idModule-Student")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<ModuleUser>(entity =>
            {
                entity.HasKey(e => new { e.IdModule, e.IdUser })
                    .HasName("PRIMARY");

                entity.ToTable("module_user", "info2017");

                entity.Property(e => e.IdModule)
                    .HasColumnName("idModule")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUser)
                    .HasColumnName("idUser")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdModuleNavigation)
                    .WithMany(p => p.ModuleUser)
                    .HasForeignKey(d => d.IdModule)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("idmodule");
            });

            modelBuilder.Entity<Permisos>(entity =>
            {
                entity.HasKey(e => e.IdPermiso)
                    .HasName("PRIMARY");

                entity.ToTable("permisos", "info2017");

                entity.Property(e => e.IdPermiso)
                    .HasColumnName("idPermiso")
                    .HasColumnType("int(8)");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("int(8)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(35)")
                    .HasMaxLength(35);

                entity.Property(e => e.Permiso)
                    .HasColumnName("permiso")
                    .HasColumnType("int(8)");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.IdPost)
                    .HasName("PRIMARY");

                entity.ToTable("post", "info2017");

                entity.HasIndex(e => e.ModuleIdmodule)
                    .HasName("fk_post_module1_idx");

                entity.HasIndex(e => e.TeacherIdTeacher)
                    .HasName("fk_post_Teacher1_idx");

                entity.Property(e => e.IdPost)
                    .HasColumnName("idPost")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    .HasMaxLength(150);

                entity.Property(e => e.ModuleIdmodule)
                    .HasColumnName("module_idmodule")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TeacherIdTeacher)
                    .HasColumnName("Teacher_idTeacher")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.HasOne(d => d.ModuleIdmoduleNavigation)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.ModuleIdmodule)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_post_module1");

                entity.HasOne(d => d.TeacherIdTeacherNavigation)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.TeacherIdTeacher)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_post_Teacher1");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PRIMARY");

                entity.ToTable("roles", "info2017");

                entity.Property(e => e.IdRol)
                    .HasColumnName("idRol")
                    .HasColumnType("int(8)");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("int(8)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(30)")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<RolesPermisos>(entity =>
            {
                entity.HasKey(e => e.IdRolPermiso)
                    .HasName("PRIMARY");

                entity.ToTable("roles_permisos", "info2017");

                entity.HasIndex(e => e.IdPermiso)
                    .HasName("idPermiso");

                entity.HasIndex(e => e.IdRol)
                    .HasName("idRol");

                entity.Property(e => e.IdRolPermiso)
                    .HasColumnName("idRolPermiso")
                    .HasColumnType("int(8)");

                entity.Property(e => e.IdPermiso)
                    .HasColumnName("idPermiso")
                    .HasColumnType("int(8)");

                entity.Property(e => e.IdRol)
                    .HasColumnName("idRol")
                    .HasColumnType("int(8)");

                entity.HasOne(d => d.IdPermisoNavigation)
                    .WithMany(p => p.RolesPermisos)
                    .HasForeignKey(d => d.IdPermiso)
                    .HasConstraintName("roles_permisos_ibfk_2");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.RolesPermisos)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("roles_permisos_ibfk_1");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.Idschedule)
                    .HasName("PRIMARY");

                entity.ToTable("schedule", "info2017");

                entity.Property(e => e.Idschedule)
                    .HasColumnName("idschedule")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Support>(entity =>
            {
                entity.HasKey(e => e.IdSupport)
                    .HasName("PRIMARY");

                entity.ToTable("support", "info2017");

                entity.HasIndex(e => e.ModuleIdmodule)
                    .HasName("fk_Support_module1_idx");

                entity.Property(e => e.IdSupport)
                    .HasColumnName("idSupport")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModuleIdmodule)
                    .HasColumnName("module_idmodule")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.HasOne(d => d.ModuleIdmoduleNavigation)
                    .WithMany(p => p.Support)
                    .HasForeignKey(d => d.ModuleIdmodule)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_Support_module1");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.IdTeacher)
                    .HasName("PRIMARY");

                entity.ToTable("teacher", "info2017");

                entity.HasIndex(e => e.ModuleIdmodule)
                    .HasName("fk_Teacher_module1_idx");

                entity.HasIndex(e => e.UsuariosRolesIdUsuarioRol)
                    .HasName("fk_Teacher_usuarios_roles1_idx");

                entity.Property(e => e.IdTeacher)
                    .HasColumnName("idTeacher")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModuleIdmodule)
                    .HasColumnName("module_idmodule")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.Property(e => e.UsuariosRolesIdUsuarioRol)
                    .HasColumnName("usuarios_roles_idUsuarioRol")
                    .HasColumnType("int(8)");

                entity.HasOne(d => d.ModuleIdmoduleNavigation)
                    .WithMany(p => p.Teacher)
                    .HasForeignKey(d => d.ModuleIdmodule)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_Teacher_module1");

                entity.HasOne(d => d.UsuariosRolesIdUsuarioRolNavigation)
                    .WithMany(p => p.Teacher)
                    .HasForeignKey(d => d.UsuariosRolesIdUsuarioRol)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_Teacher_usuarios_roles1");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuarios", "info2017");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(8)");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasColumnType("varchar(200)")
                    .HasMaxLength(200);

                entity.Property(e => e.Dni)
                    .HasColumnName("dni")
                    .HasColumnType("int(8)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(30)")
                    .HasMaxLength(30);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("Fecha_nacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.IdLocalidad)
                    .HasColumnName("idLocalidad")
                    .HasColumnType("int(8)");

                entity.Property(e => e.IdRol)
                    .HasColumnName("idRol")
                    .HasColumnType("int(8)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasColumnType("int(15)");
            });

            modelBuilder.Entity<UsuariosRoles>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioRol)
                    .HasName("PRIMARY");

                entity.ToTable("usuarios_roles", "info2017");

                entity.HasIndex(e => e.IdRol)
                    .HasName("idRol");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("idUsuario");

                entity.Property(e => e.IdUsuarioRol)
                    .HasColumnName("idUsuarioRol")
                    .HasColumnType("int(8)");

                entity.Property(e => e.IdRol)
                    .HasColumnName("idRol")
                    .HasColumnType("int(8)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(8)");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.UsuariosRoles)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("usuarios_roles_ibfk_2");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuariosRoles)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("usuarios_roles_ibfk_1");
            });
        }
    }
}