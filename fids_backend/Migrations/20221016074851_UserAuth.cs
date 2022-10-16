using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fids_backend.Migrations
{
    public partial class UserAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Agency",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Short",
                table: "AspNetUsers",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agency",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Short",
                table: "AspNetUsers");
        }
    }
}
