using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientServer_ORM_Lab2.Migrations
{
    /// <inheritdoc />
    public partial class courseDurationAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Courses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Courses");
        }
    }
}
