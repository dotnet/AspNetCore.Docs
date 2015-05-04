using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using AngularSample.Models;

namespace AngularSample.Migrations
{
    public partial class CreateIdentitySchema : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "AspNetRoles",
                x => new
                {
                    ConcurrencyStamp = x.Column("nvarchar(max)", nullable: true),
                    Id = x.Column("nvarchar(450)", nullable: true),
                    Name = x.Column("nvarchar(max)", nullable: true),
                    NormalizedName = x.Column("nvarchar(max)", nullable: true)})
                .PrimaryKey(x => x.Id, name: "PK_AspNetRoles");
            migrationBuilder.CreateTable(
                "AspNetUserRoles",
                x => new
                {
                    RoleId = x.Column("nvarchar(450)", nullable: true),
                    UserId = x.Column("nvarchar(450)", nullable: true)})
                .PrimaryKey(x => new { x.UserId, x.RoleId }, name: "PK_AspNetUserRoles");
            migrationBuilder.CreateTable(
                "AspNetUsers",
                x => new
                {
                    AccessFailedCount = x.Column("int"),
                    ConcurrencyStamp = x.Column("nvarchar(max)", nullable: true),
                    Email = x.Column("nvarchar(max)", nullable: true),
                    EmailConfirmed = x.Column("bit"),
                    Id = x.Column("nvarchar(450)", nullable: true),
                    LockoutEnabled = x.Column("bit"),
                    LockoutEnd = x.Column("datetimeoffset", nullable: true),
                    NormalizedEmail = x.Column("nvarchar(max)", nullable: true),
                    NormalizedUserName = x.Column("nvarchar(max)", nullable: true),
                    PasswordHash = x.Column("nvarchar(max)", nullable: true),
                    PhoneNumber = x.Column("nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = x.Column("bit"),
                    SecurityStamp = x.Column("nvarchar(max)", nullable: true),
                    TwoFactorEnabled = x.Column("bit"),
                    UserName = x.Column("nvarchar(max)", nullable: true)})
                .PrimaryKey(x => x.Id, name: "PK_AspNetUsers");
            migrationBuilder.CreateTable(
                "AspNetRoleClaims",
                x => new
                {
                    ClaimType = x.Column("nvarchar(max)", nullable: true),
                    ClaimValue = x.Column("nvarchar(max)", nullable: true),
                    Id = x.Column("int", annotations: new Dictionary<string, string> { { "SqlServer:ValueGeneration", "Identity" } }),
                    RoleId = x.Column("nvarchar(450)", nullable: true)})
                .PrimaryKey(x => x.Id, name: "PK_AspNetRoleClaims")
                .ForeignKey(x => x.RoleId, "AspNetRoles", principalColumns: new string[] { "Id" }, name: "FK_AspNetRoleClaims_AspNetRoles_RoleId");
            migrationBuilder.CreateTable(
                "AspNetUserClaims",
                x => new
                {
                    ClaimType = x.Column("nvarchar(max)", nullable: true),
                    ClaimValue = x.Column("nvarchar(max)", nullable: true),
                    Id = x.Column("int", annotations: new Dictionary<string, string> { { "SqlServer:ValueGeneration", "Identity" } }),
                    UserId = x.Column("nvarchar(450)", nullable: true)})
                .PrimaryKey(x => x.Id, name: "PK_AspNetUserClaims")
                .ForeignKey(x => x.UserId, "AspNetUsers", principalColumns: new string[] { "Id" }, name: "FK_AspNetUserClaims_AspNetUsers_UserId");
            migrationBuilder.CreateTable(
                "AspNetUserLogins",
                x => new
                {
                    LoginProvider = x.Column("nvarchar(450)", nullable: true),
                    ProviderDisplayName = x.Column("nvarchar(max)", nullable: true),
                    ProviderKey = x.Column("nvarchar(450)", nullable: true),
                    UserId = x.Column("nvarchar(450)", nullable: true)})
                .PrimaryKey(x => new { x.LoginProvider, x.ProviderKey }, name: "PK_AspNetUserLogins")
                .ForeignKey(x => x.UserId, "AspNetUsers", principalColumns: new string[] { "Id" }, name: "FK_AspNetUserLogins_AspNetUsers_UserId");
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("AspNetRoles");
            migrationBuilder.DropTable("AspNetRoleClaims");
            migrationBuilder.DropTable("AspNetUserClaims");
            migrationBuilder.DropTable("AspNetUserLogins");
            migrationBuilder.DropTable("AspNetUserRoles");
            migrationBuilder.DropTable("AspNetUsers");
        }
    }

    [ContextType(typeof(ApplicationDbContext))]
    partial class CreateIdentitySchema
    {
        public override string Id
        {
            get
            {
                return "00000000000000_CreateIdentitySchema";
            }
        }

        public override string ProductVersion
        {
            get
            {
                return "7.0.0-beta4";
            }
        }

        public override IModel Target
        {
            get
            {
                var builder = new BasicModelBuilder();
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityRole", b =>
                    {
                        b.Property<string>("ConcurrencyStamp")
                            .ConcurrencyToken();
                        b.Property<string>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("Name");
                        b.Property<string>("NormalizedName");
                        b.Key("Id");
                        b.ForRelational().Table("AspNetRoles");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityRoleClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("ClaimType");
                        b.Property<string>("ClaimValue");
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("RoleId");
                        b.Key("Id");
                        b.ForRelational().Table("AspNetRoleClaims");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityUserClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("ClaimType");
                        b.Property<string>("ClaimValue");
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("UserId");
                        b.Key("Id");
                        b.ForRelational().Table("AspNetUserClaims");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityUserLogin`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("LoginProvider");
                        b.Property<string>("ProviderDisplayName");
                        b.Property<string>("ProviderKey");
                        b.Property<string>("UserId");
                        b.Key("LoginProvider", "ProviderKey");
                        b.ForRelational().Table("AspNetUserLogins");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityUserRole`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.Property<string>("RoleId");
                        b.Property<string>("UserId");
                        b.Key("UserId", "RoleId");
                        b.ForRelational().Table("AspNetUserRoles");
                    });
                
                builder.Entity("AngularSample.Models.ApplicationUser", b =>
                    {
                        b.Property<int>("AccessFailedCount");
                        b.Property<string>("ConcurrencyStamp")
                            .ConcurrencyToken();
                        b.Property<string>("Email");
                        b.Property<bool>("EmailConfirmed");
                        b.Property<string>("Id")
                            .GenerateValueOnAdd();
                        b.Property<bool>("LockoutEnabled");
                        b.Property<DateTimeOffset?>("LockoutEnd");
                        b.Property<string>("NormalizedEmail");
                        b.Property<string>("NormalizedUserName");
                        b.Property<string>("PasswordHash");
                        b.Property<string>("PhoneNumber");
                        b.Property<bool>("PhoneNumberConfirmed");
                        b.Property<string>("SecurityStamp");
                        b.Property<bool>("TwoFactorEnabled");
                        b.Property<string>("UserName");
                        b.Key("Id");
                        b.ForRelational().Table("AspNetUsers");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityRoleClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("Microsoft.AspNet.Identity.IdentityRole", "RoleId");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityUserClaim`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("AngularSample.Models.ApplicationUser", "UserId");
                    });
                
                builder.Entity("Microsoft.AspNet.Identity.IdentityUserLogin`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]", b =>
                    {
                        b.ForeignKey("AngularSample.Models.ApplicationUser", "UserId");
                    });
                
                return builder.Model;
            }
        }
    }
}