using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProyectoNETLocalDB.Migrations
{
    public partial class InfoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActualModules",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActualModulo = table.Column<int>(nullable: false),
                    TeacherID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualModules", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateEvaluation = table.Column<DateTime>(nullable: false),
                    ModuleID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Evaluations_Modules_ModuleID",
                        column: x => x.ModuleID,
                        principalTable: "Modules",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModuleID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Students_Modules_ModuleID",
                        column: x => x.ModuleID,
                        principalTable: "Modules",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModuleIDID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Teachers_Modules_ModuleIDID",
                        column: x => x.ModuleIDID,
                        principalTable: "Modules",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    EvaluationID = table.Column<int>(nullable: true),
                    Note = table.Column<int>(nullable: false),
                    StudentID = table.Column<int>(nullable: true),
                    TeacherID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Evaluations_EvaluationID",
                        column: x => x.EvaluationID,
                        principalTable: "Evaluations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FileDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentType = table.Column<string>(nullable: true),
                    CreatedTimestamp = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    ModuleName = table.Column<string>(nullable: true),
                    ModuloID = table.Column<int>(nullable: true),
                    TeacherID = table.Column<int>(nullable: true),
                    TeacherName = table.Column<string>(nullable: true),
                    UpdatedTimestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileDescriptions_Modules_ModuloID",
                        column: x => x.ModuloID,
                        principalTable: "Modules",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FileDescriptions_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ModuleID = table.Column<int>(nullable: true),
                    NameTeacher = table.Column<string>(nullable: true),
                    TeacherID = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Modules_ModuleID",
                        column: x => x.ModuleID,
                        principalTable: "Modules",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_ModuleID",
                table: "Evaluations",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_EvaluationID",
                table: "Feedbacks",
                column: "EvaluationID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_StudentID",
                table: "Feedbacks",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_TeacherID",
                table: "Feedbacks",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_FileDescriptions_ModuloID",
                table: "FileDescriptions",
                column: "ModuloID");

            migrationBuilder.CreateIndex(
                name: "IX_FileDescriptions_TeacherID",
                table: "FileDescriptions",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ModuleID",
                table: "Posts",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TeacherID",
                table: "Posts",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ModuleID",
                table: "Students",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ModuleIDID",
                table: "Teachers",
                column: "ModuleIDID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActualModules");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "FileDescriptions");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Modules");
        }
    }
}
