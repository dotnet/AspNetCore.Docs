using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Migrations
{
    public partial class Rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Movie",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Rating", "ReleaseDate" },
                values: new object[] { "R", new DateTime(1989, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "ID",
                keyValue: 2,
                column: "Rating",
                value: "G");

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "ID",
                keyValue: 3,
                column: "Rating",
                value: "G");

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "ID",
                keyValue: 4,
                column: "Rating",
                value: "NA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movie");

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "ID",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(1989, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
