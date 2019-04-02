using Microsoft.EntityFrameworkCore.Migrations;

namespace BankWebApplication.Data.Migrations
{
    public partial class AddBIC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BIC",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BIC",
                table: "AspNetUsers");
        }
    }
}
