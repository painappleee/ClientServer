using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientServer_ORM_Lab2.Migrations
{
    /// <inheritdoc />
    public partial class onModelCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Courses_CoursesId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Students_StudentsId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTeacher_Courses_CoursesId",
                table: "CourseTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTeacher_Teachers_TeachersId",
                table: "CourseTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTeacher",
                table: "CourseTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent");

            migrationBuilder.RenameTable(
                name: "CourseTeacher",
                newName: "CourseTeachers");

            migrationBuilder.RenameTable(
                name: "CourseStudent",
                newName: "CourseStudents");

            migrationBuilder.RenameColumn(
                name: "TeachersId",
                table: "CourseTeachers",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "CoursesId",
                table: "CourseTeachers",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTeacher_TeachersId",
                table: "CourseTeachers",
                newName: "IX_CourseTeachers_TeacherId");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "CourseStudents",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "CoursesId",
                table: "CourseStudents",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudent_StudentsId",
                table: "CourseStudents",
                newName: "IX_CourseStudents_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTeachers",
                table: "CourseTeachers",
                columns: new[] { "CourseId", "TeacherId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudents",
                table: "CourseStudents",
                columns: new[] { "CourseId", "StudentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudents_Courses_CourseId",
                table: "CourseStudents",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudents_Students_StudentId",
                table: "CourseStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTeachers_Courses_CourseId",
                table: "CourseTeachers",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTeachers_Teachers_TeacherId",
                table: "CourseTeachers",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudents_Courses_CourseId",
                table: "CourseStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudents_Students_StudentId",
                table: "CourseStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTeachers_Courses_CourseId",
                table: "CourseTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTeachers_Teachers_TeacherId",
                table: "CourseTeachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTeachers",
                table: "CourseTeachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudents",
                table: "CourseStudents");

            migrationBuilder.RenameTable(
                name: "CourseTeachers",
                newName: "CourseTeacher");

            migrationBuilder.RenameTable(
                name: "CourseStudents",
                newName: "CourseStudent");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "CourseTeacher",
                newName: "TeachersId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseTeacher",
                newName: "CoursesId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTeachers_TeacherId",
                table: "CourseTeacher",
                newName: "IX_CourseTeacher_TeachersId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "CourseStudent",
                newName: "StudentsId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseStudent",
                newName: "CoursesId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudents_StudentId",
                table: "CourseStudent",
                newName: "IX_CourseStudent_StudentsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTeacher",
                table: "CourseTeacher",
                columns: new[] { "CoursesId", "TeachersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent",
                columns: new[] { "CoursesId", "StudentsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Courses_CoursesId",
                table: "CourseStudent",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Students_StudentsId",
                table: "CourseStudent",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTeacher_Courses_CoursesId",
                table: "CourseTeacher",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTeacher_Teachers_TeachersId",
                table: "CourseTeacher",
                column: "TeachersId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
