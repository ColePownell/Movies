using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Migrations
{
    public partial class Director : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "DirectorId", "FirstMovie", "Name" },
                values: new object[] { 1, "test movie1", "Test Name1" });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "DirectorId", "FirstMovie", "Name" },
                values: new object[] { 2, "test movie2", "Test Name2" });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "DirectorId", "FirstMovie", "Name" },
                values: new object[] { 3, "test movie3", "Test Name3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "DirectorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "DirectorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "DirectorId",
                keyValue: 3);
        }
    }
}
