using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace ContosoBooks.Migrations
{
    public partial class Initial : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateSequence(
                name: "DefaultSequence",
                type: "bigint",
                startWith: 1L,
                incrementBy: 10);
            migration.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorID = table.Column(type: "int", nullable: false),
                    FirstMidName = table.Column(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorID);
                });
            migration.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookID = table.Column(type: "int", nullable: false),
                    AuthorID = table.Column(type: "int", nullable: false),
                    Genre = table.Column(type: "nvarchar(max)", nullable: true),
                    Price = table.Column(type: "decimal(18, 2)", nullable: false),
                    Title = table.Column(type: "nvarchar(max)", nullable: true),
                    Year = table.Column(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorID",
                        columns: x => x.AuthorID,
                        referencedTable: "Author",
                        referencedColumn: "AuthorID");
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropSequence("DefaultSequence");
            migration.DropTable("Author");
            migration.DropTable("Book");
        }
    }
}
