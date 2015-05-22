using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using Microsoft.Data.Entity.Relational.Migrations.Operations;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    public partial class CreateIdentitySchema : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    AccessFailedCount = table.Column(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column(type: "nvarchar(max)", nullable: true),
                    Email = table.Column(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column(type: "bit", nullable: false),
                    Id = table.Column(type: "nvarchar(450)", nullable: true),
                    LockoutEnabled = table.Column(type: "bit", nullable: false),
                    LockoutEnd = table.Column(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column(type: "bit", nullable: false),
                    SecurityStamp = table.Column(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column(type: "bit", nullable: false),
                    UserName = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });
            migration.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    ConcurrencyStamp = table.Column(type: "nvarchar(max)", nullable: true),
                    Id = table.Column(type: "nvarchar(450)", nullable: true),
                    Name = table.Column(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });
            migration.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    ClaimType = table.Column(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column(type: "nvarchar(max)", nullable: true),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    UserId = table.Column(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        columns: x => x.UserId,
                        referencedTable: "AspNetUsers",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column(type: "nvarchar(450)", nullable: true),
                    ProviderDisplayName = table.Column(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        columns: x => x.UserId,
                        referencedTable: "AspNetUsers",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    ClaimType = table.Column(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column(type: "nvarchar(max)", nullable: true),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    RoleId = table.Column(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        columns: x => x.RoleId,
                        referencedTable: "AspNetRoles",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    RoleId = table.Column(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        columns: x => x.RoleId,
                        referencedTable: "AspNetRoles",
                        referencedColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        columns: x => x.UserId,
                        referencedTable: "AspNetUsers",
                        referencedColumn: "Id");
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("AspNetUserRoles");
            migration.DropTable("AspNetRoleClaims");
            migration.DropTable("AspNetUserLogins");
            migration.DropTable("AspNetUserClaims");
            migration.DropTable("AspNetRoles");
            migration.DropTable("AspNetUsers");
        }
    }

    [ContextType(typeof(ApplicationDbContext))]
    partial class CreateIdentitySchema
    {
        public override string Id
        {
            get { return "00000000000000_CreateIdentitySchema"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta4"; }
        }

        public override IModel Target
        {
            get
            {
                var builder = new BasicModelBuilder()
                    .Annotation("SqlServer:ValueGeneration", "Identity");

                builder.Entity("WebApplication1.Models.ApplicationUser", b =>
                    {
                        b.Property<int>("AccessFailedCount")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<string>("ConcurrencyStamp")
                            .ConcurrencyToken()
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<string>("Email")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<bool>("EmailConfirmed")
                            .Annotation("OriginalValueIndex", 3);
                        b.Property<string>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 4);
                        b.Property<bool>("LockoutEnabled")
                            .Annotation("OriginalValueIndex", 5);
                        b.Property<DateTimeOffset?>("LockoutEnd")
                            .Annotation("OriginalValueIndex", 6);
                        b.Property<string>("NormalizedEmail")
                            .Annotation("OriginalValueIndex", 7);
                        b.Property<string>("NormalizedUserName")
                            .Annotation("OriginalValueIndex", 8);
                        b.Property<string>("PasswordHash")
                            .Annotation("OriginalValueIndex", 9);
                        b.Property<string>("PhoneNumber")
                            .Annotation("OriginalValueIndex", 10);
                        b.Property<bool>("PhoneNumberConfirmed")
                            .Annotation("OriginalValueIndex", 11);
                        b.Property<string>("SecurityStamp")
                            .Annotation("OriginalValueIndex", 12);
                        b.Property<bool>("TwoFactorEnabled")
                            .Annotation("OriginalValueIndex", 13);
                        b.Property<string>("UserName")
                            .Annotation("OriginalValueIndex", 14);
                        b.Key("Id");
                        b.Annotation("Relational:TableName", "AspNetUsers");
                    });

                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                    {
                        b.Property<string>("ConcurrencyStamp")
                            .ConcurrencyToken()
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<string>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<string>("Name")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<string>("NormalizedName")
                            .Annotation("OriginalValueIndex", 3);
                        b.Key("Id");
                        b.Annotation("Relational:TableName", "AspNetRoles");
                    });

                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]", b =>
                    {
                        b.Property<string>("ClaimType")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<string>("ClaimValue")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 2)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("RoleId")
                            .Annotation("OriginalValueIndex", 3);
                        b.Key("Id");
                        b.Annotation("Relational:TableName", "AspNetRoleClaims");
                    });

                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]", b =>
                    {
                        b.Property<string>("ClaimType")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<string>("ClaimValue")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 2)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("UserId")
                            .Annotation("OriginalValueIndex", 3);
                        b.Key("Id");
                        b.Annotation("Relational:TableName", "AspNetUserClaims");
                    });

                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]", b =>
                    {
                        b.Property<string>("LoginProvider")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<string>("ProviderDisplayName")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<string>("ProviderKey")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<string>("UserId")
                            .Annotation("OriginalValueIndex", 3);
                        b.Key("LoginProvider", "ProviderKey");
                        b.Annotation("Relational:TableName", "AspNetUserLogins");
                    });

                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]", b =>
                    {
                        b.Property<string>("RoleId")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<string>("UserId")
                            .Annotation("OriginalValueIndex", 1);
                        b.Key("UserId", "RoleId");
                        b.Annotation("Relational:TableName", "AspNetUserRoles");
                    });

                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]", b =>
                    {
                        b.ForeignKey("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", "RoleId");
                    });

                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]", b =>
                    {
                        b.ForeignKey("WebApplication1.Models.ApplicationUser", "UserId");
                    });

                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]", b =>
                    {
                        b.ForeignKey("WebApplication1.Models.ApplicationUser", "UserId");
                    });

                builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]", b =>
                    {
                        b.ForeignKey("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", "RoleId");
                        b.ForeignKey("WebApplication1.Models.ApplicationUser", "UserId");
                    });

                return builder.Model;
            }
        }
    }
}
