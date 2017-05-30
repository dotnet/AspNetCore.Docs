using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using ContactManager.Models;

namespace ContactManager.Data.Migrations
{
    public partial class changes20170429 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Contact",
                nullable: false,
                defaultValue: ContactStatus.Submitted);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Contact");
        }
    }
}
