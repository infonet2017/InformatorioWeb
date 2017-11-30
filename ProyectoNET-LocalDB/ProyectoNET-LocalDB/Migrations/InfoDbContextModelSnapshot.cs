﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ProyectoNET_LocalDB.Models;
using System;

namespace ProyectoNETLocalDB.Migrations
{
    [DbContext(typeof(InfoDbContext))]
    partial class InfoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProyectoNET_LocalDB.Models.ActualModule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActualModulo");

                    b.Property<int>("TeacherID");

                    b.HasKey("ID");

                    b.ToTable("ActualModules");
                });

            modelBuilder.Entity("ProyectoNET_LocalDB.Models.FileDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentType");

                    b.Property<DateTime>("CreatedTimestamp");

                    b.Property<string>("Description");

                    b.Property<string>("FileName");

                    b.Property<string>("ModuleName");

                    b.Property<int?>("ModuloID");

                    b.Property<int?>("TeacherID");

                    b.Property<string>("TeacherName");

                    b.Property<DateTime>("UpdatedTimestamp");

                    b.HasKey("Id");

                    b.HasIndex("ModuloID");

                    b.HasIndex("TeacherID");

                    b.ToTable("FileDescriptions");
                });

            modelBuilder.Entity("ProyectoNET_LocalDB.Models.Module", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("ProyectoNET_LocalDB.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Description");

                    b.Property<int?>("ModuleID");

                    b.Property<string>("NameTeacher");

                    b.Property<int?>("TeacherID");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ModuleID");

                    b.HasIndex("TeacherID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("ProyectoNET_LocalDB.Models.Teacher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ModuleIDID");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("ModuleIDID");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("ProyectoNET_LocalDB.Models.FileDescription", b =>
                {
                    b.HasOne("ProyectoNET_LocalDB.Models.Module", "Modulo")
                        .WithMany("FileShortDescriptions")
                        .HasForeignKey("ModuloID");

                    b.HasOne("ProyectoNET_LocalDB.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherID");
                });

            modelBuilder.Entity("ProyectoNET_LocalDB.Models.Post", b =>
                {
                    b.HasOne("ProyectoNET_LocalDB.Models.Module", "Module")
                        .WithMany("Posts")
                        .HasForeignKey("ModuleID");

                    b.HasOne("ProyectoNET_LocalDB.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherID");
                });

            modelBuilder.Entity("ProyectoNET_LocalDB.Models.Teacher", b =>
                {
                    b.HasOne("ProyectoNET_LocalDB.Models.Module", "ModuleID")
                        .WithMany("Teachers")
                        .HasForeignKey("ModuleIDID");
                });
#pragma warning restore 612, 618
        }
    }
}
