using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoNET_DB.Info2017
{
    public partial class info2017Context : DbContext
    {
        public virtual DbSet<Actualmodule> Actualmodule { get; set; }
        public virtual DbSet<Auxiliarmodules> Auxiliarmodules { get; set; }
        public virtual DbSet<Evaluation> Evaluation { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Filedescription> Filedescription { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=br-cdbr-azure-south-b.cloudapp.net;port=3306;user=bc024701276aa4;password=f6faf138;database=info2017");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actualmodule>(entity =>
            {
                entity.HasKey(e => e.IdActualModule);

                entity.ToTable("actualmodule");

                entity.Property(e => e.IdActualModule)
                    .HasColumnName("idActualModule")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ActualModule)
                    .HasColumnName("actualModule")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTeacher)
                    .HasColumnName("idTeacher")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Auxiliarmodules>(entity =>
            {
                entity.HasKey(e => e.IdauxiliarModules);

                entity.ToTable("auxiliarmodules");

                entity.Property(e => e.IdauxiliarModules)
                    .HasColumnName("idauxiliarModules")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(45);

                entity.Property(e => e.IdModule)
                    .HasColumnName("idModule")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Evaluation>(entity =>
            {
                entity.HasKey(e => e.IdEvaluation);

                entity.ToTable("evaluation");

                entity.HasIndex(e => e.IdModule)
                    .HasName("fk_Evaluation_module1_idx");

                entity.Property(e => e.IdEvaluation)
                    .HasColumnName("idEvaluation")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DateEvaluation)
                    .HasColumnName("dateEvaluation")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdModule)
                    .HasColumnName("idModule")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdModuleNavigation)
                    .WithMany(p => p.Evaluation)
                    .HasForeignKey(d => d.IdModule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Evaluation_module1");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.Idfeedback);

                entity.ToTable("feedback");

                entity.HasIndex(e => e.IdEvaluation)
                    .HasName("fk_feedback_evaluation1_idx");

                entity.HasIndex(e => e.IdStudent)
                    .HasName("fk_feedback_userStudent_idx");

                entity.HasIndex(e => e.IdTeacher)
                    .HasName("fk_feedback_userTeacher_idx");

                entity.Property(e => e.Idfeedback)
                    .HasColumnName("idfeedback")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.IdEvaluation)
                    .HasColumnName("idEvaluation")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdStudent)
                    .HasColumnName("idStudent")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTeacher)
                    .HasColumnName("idTeacher")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdEvaluationNavigation)
                    .WithMany(p => p.Feedback)
                    .HasForeignKey(d => d.IdEvaluation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_feedback_evaluation1");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.FeedbackIdStudentNavigation)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_feedback_userStudent");

                entity.HasOne(d => d.IdTeacherNavigation)
                    .WithMany(p => p.FeedbackIdTeacherNavigation)
                    .HasForeignKey(d => d.IdTeacher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_feedback_userTeacher");
            });

            modelBuilder.Entity<Filedescription>(entity =>
            {
                entity.HasKey(e => e.IdfileDescription);

                entity.ToTable("filedescription");

                entity.HasIndex(e => e.IdModule)
                    .HasName("fk_fileDescription_module_idx");

                entity.HasIndex(e => e.IdTeacher)
                    .HasName("fk_fileDescription_teacher_idx");

                entity.Property(e => e.IdfileDescription)
                    .HasColumnName("idfileDescription")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContentType)
                    .HasColumnName("contentType")
                    .HasMaxLength(45);

                entity.Property(e => e.CreatedTimestamp)
                    .HasColumnName("createdTimestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(45);

                entity.Property(e => e.FileName)
                    .HasColumnName("fileName")
                    .HasMaxLength(45);

                entity.Property(e => e.IdModule)
                    .HasColumnName("idModule")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTeacher)
                    .HasColumnName("idTeacher")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasColumnName("moduleName")
                    .HasMaxLength(45);

                entity.Property(e => e.TeacherName)
                    .IsRequired()
                    .HasColumnName("teacherName")
                    .HasMaxLength(45);

                entity.Property(e => e.UpdatedTimestamp)
                    .HasColumnName("updatedTimestamp")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdModuleNavigation)
                    .WithMany(p => p.Filedescription)
                    .HasForeignKey(d => d.IdModule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_fileDescription_module");

                entity.HasOne(d => d.IdTeacherNavigation)
                    .WithMany(p => p.Filedescription)
                    .HasForeignKey(d => d.IdTeacher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_fileDescription_users");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => e.Idmodule);

                entity.ToTable("module");

                entity.HasIndex(e => e.IdCourse)
                    .HasName("fk_module_course_idx");

                entity.HasIndex(e => e.IdModuleStudent)
                    .HasName("fk_module_course_idx1");

                entity.Property(e => e.Idmodule)
                    .HasColumnName("idmodule")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(45);

                entity.Property(e => e.IdCourse)
                    .HasColumnName("idCourse")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdModuleStudent)
                    .HasColumnName("idModule-Student")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.IdPost);

                entity.ToTable("post");

                entity.HasIndex(e => e.IdModule)
                    .HasName("fk_post_module1_idx");

                entity.HasIndex(e => e.IdTeacher)
                    .HasName("fk_post_teacher");

                entity.Property(e => e.IdPost)
                    .HasColumnName("idPost")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DateTime)
                    .HasColumnName("dateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(150);

                entity.Property(e => e.IdModule)
                    .HasColumnName("idModule")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTeacher)
                    .HasColumnName("idTeacher")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NameTeacher)
                    .HasColumnName("nameTeacher")
                    .HasMaxLength(45);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdModuleNavigation)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.IdModule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_post_module1");

                entity.HasOne(d => d.IdTeacherNavigation)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.IdTeacher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_post_teacher");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Idstudent);

                entity.ToTable("student");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_student_usuario");

                entity.Property(e => e.Idstudent)
                    .HasColumnName("idstudent")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(8)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_student_usuario");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.IdTeacher);

                entity.ToTable("teacher");

                entity.HasIndex(e => e.IdAuxiliarModules)
                    .HasName("fk_teacher_auxiliarmodules_idx");

                entity.HasIndex(e => e.IdUser)
                    .HasName("fk_teacher_users");

                entity.Property(e => e.IdTeacher)
                    .HasColumnName("idTeacher")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdAuxiliarModules)
                    .HasColumnName("idAuxiliarModules")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUser)
                    .HasColumnName("idUser")
                    .HasColumnType("int(8)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdAuxiliarModulesNavigation)
                    .WithMany(p => p.Teacher)
                    .HasForeignKey(d => d.IdAuxiliarModules)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_teacher_auxiliarmodules");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Teacher)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_teacher_users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(8)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(200);

                entity.Property(e => e.Dni)
                    .HasColumnName("dni")
                    .HasColumnType("int(8)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(30);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(50);

                entity.Property(e => e.IdLocality)
                    .HasColumnName("id_locality")
                    .HasColumnType("int(2)");

                entity.Property(e => e.IdRol)
                    .HasColumnName("id_rol")
                    .HasColumnType("int(8)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("int(15)");
            });
        }
    }
}
