using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlannerApplication.Migrations
{
    public partial class AzureInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "austin2024",
                column: "Password",
                value: "4321");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "ben.j.smith99",
                column: "Password",
                value: "1234");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "Password" },
                values: new object[] { "smarquis", "Skyler Marquis", "IloveC#" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "smarquis");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");
        }
    }
}
