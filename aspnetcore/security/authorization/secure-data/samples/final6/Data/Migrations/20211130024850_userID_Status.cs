using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactManager.Data.Migrations
{
    public partial class userID_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Contact",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Contact");
        }
    }
}
