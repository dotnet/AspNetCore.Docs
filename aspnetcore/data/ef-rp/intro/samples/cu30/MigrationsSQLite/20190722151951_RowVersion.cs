#if SQLiteVersion

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContosoUniversity.Migrations
{
    public partial class RowVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Department",
                rowVersion: true,
                nullable: true);

            migrationBuilder.Sql(
            @"
                UPDATE Department
                SET RowVersion = randomblob(8)
            ");

            migrationBuilder.Sql(
            @"
                CREATE TRIGGER SetRowVersionOnUpdate
                AFTER UPDATE ON Department
                BEGIN
                    UPDATE Department
                    SET RowVersion = randomblob(8)
                    WHERE rowid = NEW.rowid;
                END
            ");

            migrationBuilder.Sql(
            @"
                CREATE TRIGGER SetRowVersionOnInsert
                AFTER INSERT ON Department
                BEGIN
                    UPDATE Department
                    SET RowVersion = randomblob(8)
                    WHERE rowid = NEW.rowid;
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Department");
        }
    }
}

#endif