using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassroomApp.DataAccess.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gradings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AssignmentId = table.Column<Guid>(nullable: true),
                    studentId = table.Column<Guid>(nullable: true),
                    Grade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gradings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    AssignmentId = table.Column<Guid>(nullable: true),
                    ClassroomId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    classroomId = table.Column<Guid>(nullable: true),
                    teacherId = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Deadline = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    teacherId = table.Column<Guid>(nullable: true),
                    classroomId = table.Column<Guid>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    classroomId = table.Column<Guid>(nullable: true),
                    studentId = table.Column<Guid>(nullable: true),
                    Confirmation = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Students_studentId",
                        column: x => x.studentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ClassroomId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    teacherId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Teachers_teacherId",
                        column: x => x.teacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    groupId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classrooms_Groups_groupId",
                        column: x => x.groupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_classroomId",
                table: "Assignments",
                column: "classroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_teacherId",
                table: "Assignments",
                column: "teacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_groupId",
                table: "Classrooms",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "IX_Gradings_AssignmentId",
                table: "Gradings",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Gradings_studentId",
                table: "Gradings",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_teacherId",
                table: "Groups",
                column: "teacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_classroomId",
                table: "Messages",
                column: "classroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_teacherId",
                table: "Messages",
                column: "teacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_classroomId",
                table: "Requests",
                column: "classroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_studentId",
                table: "Requests",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AssignmentId",
                table: "Students",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassroomId",
                table: "Students",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ClassroomId",
                table: "Teachers",
                column: "ClassroomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gradings_Assignments_AssignmentId",
                table: "Gradings",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gradings_Students_studentId",
                table: "Gradings",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classrooms_ClassroomId",
                table: "Students",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Assignments_AssignmentId",
                table: "Students",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Classrooms_classroomId",
                table: "Assignments",
                column: "classroomId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Teachers_teacherId",
                table: "Assignments",
                column: "teacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Classrooms_classroomId",
                table: "Messages",
                column: "classroomId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Teachers_teacherId",
                table: "Messages",
                column: "teacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Classrooms_classroomId",
                table: "Requests",
                column: "classroomId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Classrooms_ClassroomId",
                table: "Teachers",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Classrooms_ClassroomId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Gradings");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
