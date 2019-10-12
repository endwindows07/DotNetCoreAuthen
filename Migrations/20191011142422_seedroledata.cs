using Microsoft.EntityFrameworkCore.Migrations;

namespace netcoreAuthen.Migrations
{
    public partial class seedroledata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0127036c-6b2d-456a-b281-200da16e23aa", "34442ba0-3f04-41c0-b1c0-a450bd067ab1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4a63c82b-8549-41cb-8478-b414c646e9c2", "4ee0faea-63e2-41f5-898f-0270a262c0ef", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0127036c-6b2d-456a-b281-200da16e23aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a63c82b-8549-41cb-8478-b414c646e9c2");
        }
    }
}
