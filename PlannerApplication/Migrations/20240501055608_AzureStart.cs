using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlannerApplication.Migrations
{
    public partial class AzureStart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "smarquis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "Password" },
                values: new object[] { "smarquis", "Skyler Marquis", "IloveC#" });
        }
    }
}
